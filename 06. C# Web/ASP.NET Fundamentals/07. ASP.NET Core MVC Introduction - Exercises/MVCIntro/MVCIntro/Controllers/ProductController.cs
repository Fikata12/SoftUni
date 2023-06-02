using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntro.Models.Product;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MVCIntro.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50
			}
		};
		public IActionResult All(string keyword)
		{
			return View(products);
		}

		public IActionResult ById(int id)
		{
			if (id == 0)
			{
				return Redirect("All");
			}

			var product = products.FirstOrDefault(x => x.Id == id);

			if (product == null)
			{
				return Redirect("All");
			}

			return View(product);
		}

		public IActionResult ByName(string keyword)
		{
			if (keyword == null)
			{
				return Redirect("All");
			}

			var foundProducts = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

			if (foundProducts.Count() == 0)
			{
				return Redirect("All");
			}

			return View(foundProducts);
		}

		public IActionResult AllAsJson()
		{
			return Json(products, new JsonSerializerOptions()
			{
				WriteIndented = true
			});
		}

		public IActionResult AllAsText()
		{
			var text = string.Empty;
			foreach (var product in products)
			{
				text += $"Product {product.Id}: {product.Name} - {product.Price} lv." + Environment.NewLine;
			}

			return Content(text);
		}

		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var product in products)
			{
				sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
			}

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
			return File(Encoding.UTF8.GetBytes(sb.ToString().Trim()), "text/plain");
		}
	}
}
