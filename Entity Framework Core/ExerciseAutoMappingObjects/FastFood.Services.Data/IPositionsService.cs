using FastFood.Web.ViewModels.Positions;

namespace FastFood.Services.Data
{
    public interface IPositionsService
    {
        Task CreateAsync(CreatePositionInputModel inputModel);

        Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
    }
}