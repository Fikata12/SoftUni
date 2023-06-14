using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Data.Contracts;

namespace TaskBoardApp.Web.Controllers
{
	[Authorize]
	public class BoardController : Controller
	{
		private readonly IBoardService boardService;
        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }
        public async Task<IActionResult> All()
		{
			return View(await boardService.AllAsync());
		}
	}
}
