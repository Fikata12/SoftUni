using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;
using SoftUniBazar.Services.Contracts;

namespace SoftUniBazar.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext context;
        public CategoryService(BazarDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<CategoryViewModel>> AllAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
