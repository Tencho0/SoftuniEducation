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
    }
}
