namespace Forum_App.Controllers
{
    using System.Diagnostics;
    using Forum_App.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public HomeController()
        { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}