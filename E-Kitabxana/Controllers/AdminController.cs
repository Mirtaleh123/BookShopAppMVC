using E_Kitabxana.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Kitabxana.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
            var books = await _context.Books
             .Where(b => !b.IsDeleted)
             .OrderBy(b => b.Title)
             .ToListAsync();

            ViewBag.Orders = orders;
            ViewBag.Books = books;
            ViewBag.TotalOrders = orders.Count;
            ViewBag.TotalBooks = books.Count;
            ViewBag.PendingOrders = orders.Count(o => o.Status == "Gözləyir");
            ViewBag.TotalRevenue = orders
                .Where(o => o.Status != "Ləğv edildi")
                .Sum(o => o.TotalPrice);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
