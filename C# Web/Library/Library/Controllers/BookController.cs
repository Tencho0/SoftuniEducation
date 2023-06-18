namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Library.Contracts;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await this.bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await this.bookService
                .GetMineBooksAsync(this.GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }
            
            var userId = this.GetUserId();

            await this.bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await this.bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction(nameof(Mine));
        }
    }
}
