using E_Kitabxana.Data;
using E_Kitabxana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Kitabxana.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Səbəti göstər
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items = await _context.Carts
                .Include(c => c.Book)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return View(items);
        }

        // Səbətə əlavə et
        [HttpPost]
        public async Task<IActionResult> Add(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return RedirectToAction("Login", "Account");
            var existing = await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.BookId == bookId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                _context.Carts.Add(new Cart
                {
                    UserId = userId!,
                    BookId = bookId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Səbətdən sil
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.Carts.FindAsync(id);
            if (item != null)
            {
                _context.Carts.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}