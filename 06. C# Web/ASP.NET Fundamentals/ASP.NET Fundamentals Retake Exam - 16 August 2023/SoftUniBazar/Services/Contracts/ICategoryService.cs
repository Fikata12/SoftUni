using SoftUniBazar.Models;

namespace SoftUniBazar.Services.Contracts
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> AllAsync();
    }
}
