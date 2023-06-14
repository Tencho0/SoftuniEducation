namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBookViewModel>> GetMineBooksAsync(string userId);
    }
}
