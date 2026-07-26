using E_Kitabxana.Data;
using E_Kitabxana.Models;
using E_Kitabxana.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Kitabxana.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST + SEARCH + PAGINATION
        public async Task<IActionResult> Index(string? search, int page = 1)
        {
            const int pageSize = 8;

            var query = _context.Books.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.ToLower();
                query = query.Where(b =>
                    b.Title!.ToLower().Contains(term) ||
                    b.Author.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginationList<Book>(items, totalCount, page, pageSize);

            return View(model);
        }

        // DETAIL
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                About = model.About
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // EDIT - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var model = new EditBookViewModel
            {
                Id = book.Id,
                Title = book.Title ?? "",
                Author = book.Author,
                Price = book.Price,
                ImageUrl = book.ImageUrl,
                About = book.About
            };

            return View(model);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBookViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Title = model.Title;
            book.Author = model.Author;
            book.Price = model.Price;
            book.ImageUrl = model.ImageUrl;
            book.About = model.About;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DELETE - GET (təsdiq səhifəsi)
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // DELETE - POST (əsl silmə əməliyyatı)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // ---- LINQ praktika action-ları ----

        [HttpGet]
        public async Task<IActionResult> TestLinq1()
        {
            var result = await _context.Books
                .AsNoTracking()
                .Where(b => b.Price < 10)
                .ToListAsync();

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Baha5()
        {
            var baha5 = await _context.Books
                .AsNoTracking()
                .OrderByDescending(b => b.Price)
                .Take(5)
                .ToListAsync();

            return Json(baha5);
        }

        [HttpGet]
        public async Task<IActionResult> SevgiAxtaris()
        {
            var axtaris = await _context.Books
                .AsNoTracking()
                .Where(b => b.Title!.ToLower().Contains("sevgi"))
                .ToListAsync();

            return Json(axtaris);
        }
    }
}