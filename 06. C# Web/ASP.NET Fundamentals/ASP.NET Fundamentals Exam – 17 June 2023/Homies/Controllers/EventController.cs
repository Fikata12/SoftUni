using Homies.Models;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
	[Authorize]
	public class EventController : Controller
	{
		private readonly IEventService eventService;
		private readonly ITypeService typeService;
		public EventController(IEventService eventService, ITypeService typeService)
		{
			this.eventService = eventService;
			this.typeService = typeService;
		}

		public async Task<IActionResult> All()
		{
			var model = await eventService.GetAllAsync();

			return View(model);
		}

		public async Task<IActionResult> Joined()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var model = await eventService.GetJoinedAsync(userId);

			return View(model);
		}

		public async Task<IActionResult> Add()
		{
			var types = await typeService.GetAllAsync();

			var model = new EventViewModel
			{
				Types = types
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(EventViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Add");
			}

			var types = await typeService.GetAllAsync();
			if (types.FirstOrDefault(t => t.Id == model.TypeId) == null)
			{
				return RedirectToAction("Add");
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await eventService.CreateAsync(userId, model);

			return RedirectToAction("All");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await eventService.GetByIdAsync(id);

			if (model == null)
			{
				return RedirectToAction("All");
			}

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (model.OrganiserId != userId)
            {
                return RedirectToAction("All");
            }

            var types = await typeService.GetAllAsync();
			model.Types = types;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EventViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Edit");
			}

			var types = await typeService.GetAllAsync();
			if (types.FirstOrDefault(t => t.Id == model.TypeId) == null)
			{
				return RedirectToAction("Edit");
			}

			await eventService.EditAsync(model, id);

			return RedirectToAction("All");
		}

		[HttpPost]
        public async Task<IActionResult> Join(int id)
        {
			var @event = await eventService.GetByIdAsync(id);

            if (@event == null)
			{
				return RedirectToAction("All");
			}

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var added = await eventService.JoinAsync(id, userId);

			if (added)
			{
                return RedirectToAction("Joined");
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var @event = await eventService.GetByIdAsync(id);

            if (@event == null)
            {
                return RedirectToAction("All");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var leaved = await eventService.LeaveAsync(id, userId);

            if (leaved)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("Joined");
        }

        public async Task<IActionResult> Details(int id)
        {
            var @event = await eventService.GetByIdAsync(id);

            if (@event == null)
            {
                return RedirectToAction("All");
            }

			var model = await eventService.Details(id);

			return View(model);
        }
    }
}
