using Book_Shop.Models;
using Book_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Book_Shop.Db;

namespace Book_Shop.Controllers
{

    public class BookController : Controller
        {
            

        // LIST + SEARCH + PAGINATION
        public IActionResult Index(string? search, int page = 1)
            {
                const int pageSize = 8;

            var query = FakeDb.books.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();

                    query = query.Where(x =>
                        x.Title.ToLower().Contains(search) ||
                        x.Author.ToLower().Contains(search));
                }

                var totalCount =  query.Count();

                var items =  query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // 🔥 ƏN VACİB HİSSƏ
                var model = new PaginationList<Book>(items, totalCount, page, pageSize);

                return View(model); // ✅ artıq PaginationList göndəririk
            }

        // DETAIL
        [Authorize]

        [HttpGet]
            public IActionResult Detail(int id)
            {
                var book = FakeDb.books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                    return NotFound();

                return View(book);
            }

        // CREATE - GET
        [Authorize(Roles = "Admin")]

        [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

        // CREATE - POST
        [Authorize(Roles = "Admin")]

        [HttpPost]
            public IActionResult Create(Book book)
            {
                if (!ModelState.IsValid)
                    return View(book);

                FakeDb.books.Add(book);
               
                return RedirectToAction("Index");
            }

        // DELETE
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            var book = FakeDb.books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            FakeDb.books.Remove(book);
            

            return RedirectToAction("Index");
        }

        // EDIT - GET
        [Authorize(Roles = "Admin")]

        [HttpGet]
            public IActionResult Edit(int id)
            {
                var book = FakeDb.books.FirstOrDefault(x => x.Id == id);

                if (book == null)
                    return NotFound();

                return View(book);
            }

        // EDIT - POST
        [Authorize(Roles = "Admin")]

        [HttpPost]
            public IActionResult Edit(Book book)
            {
                var existing = FakeDb.books.FirstOrDefault(x => x.Id == book.Id);

                if (existing == null)
                    return NotFound();

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Price = book.Price;
                existing.ImageUrl = book.ImageUrl;
                existing.About = book.About;

          

                return RedirectToAction("Index");
            }
        }
    }




