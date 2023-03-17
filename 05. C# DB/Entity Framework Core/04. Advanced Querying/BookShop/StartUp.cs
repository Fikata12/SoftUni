namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            BookShopContext context = new BookShopContext();
            Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));
        }

        // 02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 5000 && (int)b.EditionType == 2)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    Price = b.Price.ToString("f2")
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price}");
            }
            return sb.ToString().TrimEnd();
        }

        // 05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split();
            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    Price = b.Price.ToString("f2")
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price}");
            }
            return sb.ToString().TrimEnd();
        }

        // 08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var books = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
            return string.Join(Environment.NewLine, books);
        }

        // 10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} ({b.AuthorName})");
            }
            return sb.ToString().TrimEnd();
        }

        // 11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
            return count;
        }

        // 12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorFullName = $"{a.FirstName} {a.LastName}",
                    CopiesCount = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var a in authors)
            {
                sb.AppendLine($"{a.AuthorFullName} - {a.CopiesCount}");
            }
            return sb.ToString().TrimEnd();
        }

        // 13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum().ToString("f2")
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.TotalProfit}");
            }
            return sb.ToString().TrimEnd();
        }

        // 14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // 15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate!.Value.Year < 2010)
                .ToArray();
            foreach (var b in books)
            {
                b.Price += 5;
            }
            context.SaveChanges();
        }

        // 16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();
            int count = books.Count();
            foreach (var b in books)
            {
                context.Remove(b);
            }
            context.SaveChanges();
            return count;
        }
    }
}
