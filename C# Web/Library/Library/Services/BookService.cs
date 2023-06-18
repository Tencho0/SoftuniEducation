using Microsoft.AspNetCore.Mvc;

namespace Library.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using Contracts;
    using Library.Data.Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            var result = await this.dbContext.Books
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Category = b.Category.Name,
                    Author = b.Author,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                })
                .ToArrayAsync();

            return result;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMineBooksAsync(string userId)
        {
            return await dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await this.dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId,
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await this.dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                };

                await this.dbContext.IdentityUserBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await this.dbContext.IdentityUserBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (userBook != null)
            {
                this.dbContext.IdentityUserBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new 
        }
    }
}
