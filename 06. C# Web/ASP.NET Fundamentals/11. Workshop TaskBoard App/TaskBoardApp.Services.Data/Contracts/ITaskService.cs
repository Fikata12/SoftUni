using Microsoft.AspNetCore.Identity;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Data.Contracts
{
	public interface ITaskService
	{
		Task AddAsync(TaskFormModel model, string userId);
		Task<TaskDetailsViewModel> GetByIdDetailsAsync(int id);
		Task<TaskFormModel> GetByIdEditAsync(int id);
		Task<IdentityUser> GetOwnerById(int id);
		Task EditByIdAsync(int id, TaskFormModel model);
		Task<TaskViewModel> GetByIdDeleteAsync(int id);
		Task DeleteAsync(TaskViewModel model);
	}
}
