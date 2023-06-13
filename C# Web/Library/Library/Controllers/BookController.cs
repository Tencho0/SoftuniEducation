namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BookController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
