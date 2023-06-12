namespace TaskBoardApp.Services.Interfaces
{
    using TaskBoardApp.Web.ViewModels.Task;

    public interface ITaskService
    {
        Task AddAsync(string ownerId, TaskFormModel viewModel);

        Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id);
    }
}
