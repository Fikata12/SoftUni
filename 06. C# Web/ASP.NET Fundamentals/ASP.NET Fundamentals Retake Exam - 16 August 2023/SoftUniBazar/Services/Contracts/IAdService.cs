using SoftUniBazar.Models;

namespace SoftUniBazar.Services.Contracts
{
    public interface IAdService
    {
        Task<ICollection<AdViewModel>> AllAsync();
        Task AddAsync(AdFormModel model, string userId);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsOwnerAsync(string userId, int id);
        Task EditAsync(AdFormModel model, int id);
        Task<bool> IsInCartAsync(string userId, int id);
        Task AddToCartAsync(string userId, int id);
        Task RemoveFromCartAsync(string userId, int id);
        Task<ICollection<AdViewModel>> CartAsync(string userId);
        Task<AdFormModel> ByIdAsync(int id);
    }
}
