using ForumApp.Services.Data;
using ForumApp.Web.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		readonly IPostService postService;
		public PostController(IPostService postService)
		{
			this.postService = postService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> All()
		{
			return View(await postService.AllAsync());
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await postService.AddAsync(model);
				return RedirectToAction("All");
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Something went wrong!");
				return View(model);
			}
		}
		public async Task<IActionResult> Edit(int id)
		{
			var post = await postService.GetByIdAsync(id);
			return View(post);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, PostFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await postService.EditAsync(id, model);

				return RedirectToAction("All");
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Something went wrong!");
				return View(model);
			}
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await postService.RemoveByIdAsync(id);
			}
			catch (Exception)
			{
			}

			return RedirectToAction("All");
		}
	}
}
