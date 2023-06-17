namespace Homies.Contracts
{
    using Homies.Models;

    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);

        Task<EventViewModel?> GetEventByIdAsync(int id);

        Task<EditEventViewModel?> GetEventForEditByIdAsync(int id);

        Task JoinEventAsync(string userId, EventViewModel currEvent);

        Task LeaveEventAsync(string userId, EventViewModel currEvent);

        Task<AddEventViewModel> GetAddEventViewModel();

        Task AddEventAsync(AddEventViewModel model, string getUserId);

        Task EditEventAsync(EditEventViewModel model, int id);
        
        Task<DetailsEventViewModel?> GetEventByIdWithDetailsAsync(int id);
    }
}
