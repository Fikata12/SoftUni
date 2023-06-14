using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Services.Data.Contracts;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.Controllers
{
	[Authorize]
	public class TaskController : Controller
	{
		private readonly ITaskService taskService;
		private readonly IBoardService boardService;

		public TaskController(ITaskService taskService, IBoardService boardService)
		{
			this.taskService = taskService;
			this.boardService = boardService;
		}
		public async Task<IActionResult> Create()
		{
			var model = new TaskFormModel()
			{
				Boards = await boardService.AllForSelectAsync()
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Boards = await boardService.AllForSelectAsync();
				return View(model);
			}

			var allBoards = await boardService.AllForSelectAsync();
			if (allBoards.FirstOrDefault(b => b.Id == model.BoardId) == null)
			{
				ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
			}

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			await taskService.AddAsync(model, userId);

			return RedirectToAction("All", "Board");
		}

		public async Task<IActionResult> Details(int id)
		{
			var taskDetails = await taskService.GetByIdDetailsAsync(id);

			if (taskDetails == null)
			{
				return BadRequest();
			}

			return View(taskDetails);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await taskService.GetByIdEditAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string ownerId = (await taskService.GetOwnerById(id)).Id;

			if (currentUserId != ownerId)
			{
				return Unauthorized();
			}

			model.Boards = await boardService.AllForSelectAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, TaskFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Boards = await boardService.AllForSelectAsync();
				return View(model);
			}

			var allBoards = await boardService.AllForSelectAsync();
			if (allBoards.FirstOrDefault(b => b.Id == model.BoardId) == null)
			{
				ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
			}

			await taskService.EditByIdAsync(id, model);

			return RedirectToAction("All", "Board");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var model = await taskService.GetByIdDeleteAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string ownerId = (await taskService.GetOwnerById(id)).Id;

			if (currentUserId != ownerId)
			{
				return Unauthorized();
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(TaskViewModel model)
		{
			var task = await taskService.GetByIdDeleteAsync(model.Id);
			if (task == null)
			{
				return NotFound();
			}

			string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string ownerId = (await taskService.GetOwnerById(model.Id)).Id;
			if (currentUserId != ownerId)
			{
				return Unauthorized();
			}

			await taskService.DeleteAsync(task);

			return RedirectToAction("All", "Board");
		}
	}
}
