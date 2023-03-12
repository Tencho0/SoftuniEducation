using AutoMapper;
using FastFood.Data;
using FastFood.Services.Data;
using FastFood.Web.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<CreateItemViewModel> availableCategories =
                await this.itemService.GetAllAvailableCategoriesAsync();

            return this.View(availableCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.itemService.CreateAsync(model);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ItemsAllViewModels> items = await this.itemService.GetAllAsync();

            return this.View(items.ToList());
        }
    }
}
