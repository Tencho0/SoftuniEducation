using Homies.Models;

namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Contracts;

    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await this.eventService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            var model = await this.eventService.GetJoinedEventsAsync(this.GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var currEvent = await this.eventService.GetEventByIdAsync(id);

            if (currEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            await this.eventService.JoinEventAsync(this.GetUserId(), currEvent);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var currEvent = await this.eventService.GetEventByIdAsync(id);

            if (currEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            await this.eventService.LeaveEventAsync(this.GetUserId(), currEvent);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await this.eventService.GetAddEventViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.eventService.AddEventAsync(model, this.GetUserId());

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currEvent = await this.eventService.GetEventForEditByIdAsync(id);

            if (currEvent == null || currEvent?.EventOrganiser?.Id != this.GetUserId())
            {
                return RedirectToAction(nameof(All));
            }

            return View(currEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.eventService.EditEventAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var currEvent = await this.eventService.GetEventByIdWithDetailsAsync(id);

            if (currEvent == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(currEvent);
        }
    }
}
