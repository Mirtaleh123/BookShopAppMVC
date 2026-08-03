using E_Kitabxana.Data;
using E_Kitabxana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Kitabxana.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Sifariş ver
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = await _context.Carts
                .Include(c => c.Book)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return RedirectToAction("Index", "Cart");

            var order = new Order
            {
                UserId = userId!,
                OrderDate = DateTime.Now,
                Status = "Gözləyir",
                TotalPrice = cartItems.Sum(c => c.Book.Price * c.Quantity),
                OrderItems = cartItems.Select(c => new OrderItem
                {
                    BookId = c.BookId,
                    Quantity = c.Quantity,
                    Price = c.Book.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyOrders");
        }
        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order != null)
            {
                order.Status = "Ləğv edildi";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyOrders");
        }
        // Sifarişlərim
        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }
    }
}