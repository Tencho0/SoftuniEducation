using FastFood.Web.ViewModels.Items;

namespace FastFood.Services.Data
{
    public interface IItemService
    {
        Task CreateAsync(CreateItemInputModel model);

        Task<IEnumerable<ItemsAllViewModels>> GetAllAsync();

        Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync();
    }
}