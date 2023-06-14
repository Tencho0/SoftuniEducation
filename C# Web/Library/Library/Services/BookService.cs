namespace Library.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using Contracts;

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
            var result = await this.dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new AllBookViewModel()
                {
                    Id = ub.Book.Id,
                    Title = ub.Book.Title,
                    Category = ub.Book.Category.Name,
                    Author = ub.Book.Author,
                    ImageUrl = ub.Book.ImageUrl,
                    Description = ub.Book.Description,
                })
                .ToArrayAsync();

            return result;
        }
    }
}
