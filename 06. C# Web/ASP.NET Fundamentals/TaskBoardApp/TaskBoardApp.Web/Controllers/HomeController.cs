using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TaskBoardApp.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}