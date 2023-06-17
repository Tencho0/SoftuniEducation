namespace Homies.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using Contracts;
    using Homies.Data.Models;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await this.dbContext.Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await this.dbContext.EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new AllEventViewModel
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start,
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName,
                })
                .ToListAsync();
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int id)
        {
            var eventViewModel = await this.dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    CreatedOn = e.CreatedOn,
                    TypeId = e.TypeId,
                    Type = e.Type.Name,
                    OrganiserId = e.OrganiserId,
                    Organiser = e.Organiser.UserName,
                    Description = e.Description,
                })
                .FirstOrDefaultAsync();

            if (eventViewModel != null)
            {
                eventViewModel.Types = await this.dbContext.Types
                    .Select(t => new TypeViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();
            }

            return eventViewModel;
        }

        public async Task<EditEventViewModel?> GetEventForEditByIdAsync(int id)
        {
            var eventViewModel = await this.dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EditEventViewModel()
                {
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId,
                    Description = e.Description,
                    EventOrganiser = e.Organiser
                })
                .FirstOrDefaultAsync();

            if (eventViewModel != null)
            {
                eventViewModel.Types = await this.dbContext.Types
                    .Select(t => new TypeViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                    .ToListAsync();
            }

            return eventViewModel;
        }

        public async Task JoinEventAsync(string userId, EventViewModel currEvent)
        {
            bool alreadyAdded = await this.dbContext.EventParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == currEvent.Id);

            if (!alreadyAdded)
            {
                var eventParticipant = new EventParticipant()
                {
                    EventId = currEvent.Id,
                    HelperId = userId,
                };

                await this.dbContext.EventParticipants.AddAsync(eventParticipant);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task LeaveEventAsync(string userId, EventViewModel currEvent)
        {
            var eventParticipant = await this.dbContext.EventParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == currEvent.Id);

            if (eventParticipant != null)
            {
                this.dbContext.EventParticipants.Remove(eventParticipant);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddEventViewModel> GetAddEventViewModel()
        {
            var types = await this.dbContext.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            var model = new AddEventViewModel()
            {
                Types = types,
            };

            return model;
        }

        public async Task AddEventAsync(AddEventViewModel model, string getUserId)
        {
            Event newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = getUserId,
                CreatedOn = DateTime.UtcNow,

            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditEventAsync(EditEventViewModel model, int id)
        {
            var editedEvent = await this.dbContext.Events.FindAsync(id);

            if (editedEvent != null)
            {
                editedEvent.Name = model.Name;
                editedEvent.Description = model.Description;
                editedEvent.Start = model.Start;
                editedEvent.End = model.End;
                editedEvent.TypeId = model.TypeId;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<DetailsEventViewModel?> GetEventByIdWithDetailsAsync(int id)
        {
            var model = await this.dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new DetailsEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    CreatedOn = e.CreatedOn,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                    Description = e.Description,
                })
                .FirstOrDefaultAsync();

            return model;
        }
    }
}
