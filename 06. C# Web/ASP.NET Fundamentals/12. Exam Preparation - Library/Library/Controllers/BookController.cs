using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext context;

        public BookController(LibraryDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> All()
        {
            var books = await context.Books
                .AsNoTracking()
                .Select(b => new AllViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating.ToString(),
                    Category = b.Category.Name
                })
                .ToListAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var books = await context.UsersBooks
                .AsNoTracking()
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new BookMineViewModel
                {
                    Id = ub.Book.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    ImageUrl = ub.Book.ImageUrl,
                    Category = ub.Book.Category.Name
                })
                .ToListAsync();

            var model = new MineViewModel
            {
                Books = books
            };

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryAddViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            var model = new AddViewModel
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add");
            }

            if (await context.Categories.FirstOrDefaultAsync(c => c.Id == model.CategoryId) == null)
            {
                return RedirectToAction("Add");
            }

            if (await context.Books.FirstOrDefaultAsync(b => b.Title == model.Title) != null)
            {
                return RedirectToAction("Add");
            }

            if (!decimal.TryParse(model.Rating.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal rating))
            {
                return RedirectToAction("Add");
            }

            if (rating < 0 || rating > 10)
            {
                return RedirectToAction("Add");
            }

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = rating,
                ImageUrl = model.Url
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await context.Books
                .Where(b => b.Id == id)
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return RedirectToAction("All");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (book!.UsersBooks.FirstOrDefault(ub => ub.CollectorId == userId) != null)
            {
                return RedirectToAction("All");
            }

            book.UsersBooks.Add(new IdentityUserBook
            {
                CollectorId = userId,
                BookId = book.Id
            });
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await context.Books
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return RedirectToAction("Mine");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBook = book!.UsersBooks.FirstOrDefault(ub => ub.CollectorId == userId);

            if (userBook == null)
            {
                return RedirectToAction("Mine");
            }

            context.UsersBooks.Remove(userBook!);
            await context.SaveChangesAsync();

            return RedirectToAction("Mine");
        }
    }
}