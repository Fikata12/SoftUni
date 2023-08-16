using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using SoftUniBazar.Services.Contracts;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;

        public AdController(IAdService adService, ICategoryService categoryService)
        {
            this.adService = adService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            var model = await adService.AllAsync();

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new AdFormModel
            {
                Categories = await categoryService.AllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel model)
        {
            var categories = await categoryService.AllAsync();

            if (categories.FirstOrDefault(c => c.Id == model.CategoryId) == null)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "The category does not exist!");
            }

            if (!decimal.TryParse(model.Price, out decimal price))
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be a number.");
            }

            if (!ModelState.IsValid)
            {
                model = new AdFormModel
                {
                    Categories = categories
                };

                return View(model);
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await adService.AddAsync(model, userId);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exists = await adService.ExistsAsync(id);

            if (!exists)
            {
                return RedirectToAction("All");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await adService.IsOwnerAsync(userId, id))
            {
                return RedirectToAction("All");
            }

            var model = await adService.ByIdAsync(id);

            model.Categories = await categoryService.AllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormModel model, int id)
        {
            var exists = await adService.ExistsAsync(id);

            if (!exists)
            {
                return RedirectToAction("All");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await adService.IsOwnerAsync(userId, id))
            {
                return RedirectToAction("All");
            }

            var categories = await categoryService.AllAsync();

            if (categories.FirstOrDefault(c => c.Id == model.CategoryId) == null)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "The category does not exist!");
            }

            if (!decimal.TryParse(model.Price, out decimal price))
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be a number.");
            }

            if (!ModelState.IsValid)
            {
                model = new AdFormModel
                {
                    Categories = categories
                };

                return View(model);
            }

            await adService.EditAsync(model, id);

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var exists = await adService.ExistsAsync(id);

            if (!exists)
            {
                return RedirectToAction("All");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var IsInCart = await adService.IsInCartAsync(userId, id);

            if (IsInCart)
            {
                return RedirectToAction("All");
            }

            await adService.AddToCartAsync(userId, id);

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var exists = await adService.ExistsAsync(id);

            if (!exists)
            {
                return RedirectToAction("Cart");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var IsInCart = await adService.IsInCartAsync(userId, id);

            if (!IsInCart)
            {
                return RedirectToAction("Cart");
            }

            await adService.RemoveFromCartAsync(userId, id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await adService.CartAsync(userId);

            return View(model);
        }
    }
}
