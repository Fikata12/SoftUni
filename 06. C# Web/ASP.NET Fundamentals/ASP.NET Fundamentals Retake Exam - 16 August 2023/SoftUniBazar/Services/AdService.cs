using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using SoftUniBazar.Services.Contracts;

namespace SoftUniBazar.Services
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext context;
        public AdService(BazarDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<AdViewModel>> AllAsync()
        {
            return await context.Ads
                .AsNoTracking()
                .Select(a => new AdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Owner = a.Owner.UserName,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn,
                    Category = a.Category.Name
                })
                .ToListAsync();
        }

        public async Task AddAsync(AdFormModel model, string userId)
        {
            var ad = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                Price = decimal.Parse(model.Price),
                OwnerId = userId,
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = model.CategoryId
            };

            await context.Ads.AddAsync(ad);

            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await context.Ads
                .AnyAsync(a => a.Id == id);
        }

        public async Task<bool> IsOwnerAsync(string userId, int id)
        {
            if (await ExistsAsync(id))
            {
                return await context.Ads
                .AnyAsync(a => a.Id == id && a.OwnerId == userId);
            }
            return false;
        }

        public async Task EditAsync(AdFormModel model, int id)
        {
            var ad = context.Ads.FirstOrDefault(a => a.Id == id);
            if (ad != null)
            {
                ad.Name = model.Name;
                ad.Description = model.Description;
                ad.Price = decimal.Parse(model.Price);
                ad.ImageUrl = model.ImageUrl;
                ad.CategoryId = model.CategoryId;

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsInCartAsync(string userId, int id)
        {
            return await context.AdsBuyers
                .AnyAsync(ab => ab.AdId == id && ab.BuyerId == userId);
        }

        public async Task AddToCartAsync(string userId, int id)
        {
            await context.AdsBuyers.AddAsync(new AdBuyer
            {
                AdId = id,
                BuyerId = userId,
            });

            await context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string userId, int id)
        {
            var adBuyer = context.AdsBuyers
                .FirstOrDefault(ab => ab.AdId == id && ab.BuyerId == userId);

            if (adBuyer != null)
            {
                context.AdsBuyers.Remove(adBuyer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AdViewModel>> CartAsync(string userId)
        {
            return await context.AdsBuyers
                .Where(ab => ab.BuyerId == userId)
                .Select(ab => new AdViewModel
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn,
                    Category = ab.Ad.Category.Name
                })
                .ToListAsync();
        }

        public async Task<AdFormModel> ByIdAsync(int id)
        {
            return await context.Ads
                .Where(a => a.Id == id)
                .Select(a => new AdFormModel
                {
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price.ToString(),
                    ImageUrl = a.ImageUrl,
                    CategoryId = a.CategoryId,
                })
                .FirstAsync();
        }
    }
}
