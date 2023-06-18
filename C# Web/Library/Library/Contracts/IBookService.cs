namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBookViewModel>> GetMineBooksAsync(string userId);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
    }
}
