using Homies.Models;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        Task<ICollection<AllViewModel>> GetAllAsync();

        Task<ICollection<JoinedViewModel>> GetJoinedAsync(string userId);

        Task CreateAsync(string userId, EventViewModel model);

        Task<EventViewModel?> GetByIdAsync(int id);

        Task EditAsync(EventViewModel model, int id);

        Task<bool> JoinAsync(int id, string userId);

        Task<bool> LeaveAsync(int id, string userId);

        Task<DetailsViewModel> Details(int id);
    }
}
