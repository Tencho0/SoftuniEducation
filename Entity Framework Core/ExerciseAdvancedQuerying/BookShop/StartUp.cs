using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();
            //var input = int.Parse(Console.ReadLine());
            //var result = GetBooksByAuthor(db, input);
            var result = GetMostRecentBooks(db);
            Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] booksInfo = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, booksInfo);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObj);
            //AgeRestriction ageRestriction;
            //if (hasParsed)
            //{
            //    ageRestriction = (AgeRestriction)ageRestrictionObj!;

            //    //var sb = new StringBuilder();
            //    var booksInfo = context.Books
            //        .Where(b => b.AgeRestriction == ageRestriction)
            //        .OrderBy(b => b)
            //        .Select(b => b.Title)
            //        .ToArray();
            //    //  .ToList();

            //    return string.Join(Environment.NewLine, booksInfo);

            //    //booksInfo.ForEach(t => sb.AppendLine(t));
            //    //return sb.ToString().TrimEnd();
            //}

            //return null;
        }

        //Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksInfo = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksInfo = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .AsNoTracking()
                .ToList();

            return string.Join(Environment.NewLine, booksInfo.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }

        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksInfo = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputArr = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var booksInfo = context.BooksCategories
                .Where(c => inputArr.Any(i => i == c.Category.Name.ToLower()))
                .OrderBy(c => c.Book.Title)
                .Select(c => c.Book.Title)
                .ToArray();

            return string.Join(Environment.NewLine, booksInfo);
        }

        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate < convertedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToList();

            var result = String.Join(Environment.NewLine, books);
            return result;

            //var sb = new StringBuilder();
            //var booksInfo = context.Books
            //    .Where(b => b.ReleaseDate.Value < DateTime.Parse(date))
            //    .OrderByDescending(b => b.ReleaseDate)
            //    .Select(b => new { b.Title, b.EditionType, b.Price })
            //    .ToArray();

            //foreach (var book in booksInfo)
            //    sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");

            //return sb.ToString().TrimEnd();
        }


        //Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        //Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var inputTolower = input.ToLower();
            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(inputTolower))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var inputToLower = input.ToLower();
            var bookTitles = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputToLower))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books.Count(b => b.Title.Length > lengthCheck);

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Copies}")
                .ToArray();

            return string.Join(Environment.NewLine, authorsCopies);
        }

        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.Profit:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, categories);
        }

        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();
            var books = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    TopBooks = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Book.Title,
                            b.Book.ReleaseDate.Value.Year
                        })
                })
                .ToArray();

            foreach (var category in books)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.TopBooks)
                    sb.AppendLine($"{book.Title} ({book.Year})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        //Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);

            int bookCount = booksToDelete.Count();

            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();

            return bookCount;
        }
    }
}