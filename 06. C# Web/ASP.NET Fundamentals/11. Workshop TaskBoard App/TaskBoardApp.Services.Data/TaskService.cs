using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Services.Data.Contracts;
using TaskBoardApp.Web.Data;
using TaskBoardApp.Web.ViewModels.Task;
using Task = System.Threading.Tasks.Task;

namespace TaskBoardApp.Services.Data
{
	public class TaskService : ITaskService
	{
		private readonly TaskBoardAppDbContext context;
		private readonly IMapper mapper;
		public TaskService(TaskBoardAppDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task AddAsync(TaskFormModel model, string userId)
		{
			var task = mapper.Map<TaskBoardApp.Data.Models.Task>(model);
			task.OwnerId = userId;

			await context.AddAsync(task);
			await context.SaveChangesAsync();
		}

		public async Task<TaskDetailsViewModel> GetByIdDetailsAsync(int id)
		{
			return mapper.Map<TaskDetailsViewModel>(await context.Tasks
				.AsNoTracking()
				.Include("Owner")
				.Include("Board")
				.FirstOrDefaultAsync(t => t.Id == id));
		}

		public async Task<TaskFormModel> GetByIdEditAsync(int id)
		{
			return mapper.Map<TaskFormModel>(await context.Tasks
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Id == id));
		}

		public async Task<IdentityUser> GetOwnerById(int id)
		{
			return (await context.Tasks
				.AsNoTracking()
				.Include("Owner")
				.FirstAsync(t => t.Id == id)).Owner;
		}

		public async Task EditByIdAsync(int id, TaskFormModel model)
		{
			var task = await context.Tasks
				.FirstOrDefaultAsync(t => t.Id == id);

			task.Title = model.Title;
			task.Description = model.Description;
			task.BoardId = model.BoardId;

			await context.SaveChangesAsync();
		}

		public async Task<TaskViewModel> GetByIdDeleteAsync(int id)
		{
			return mapper.Map<TaskViewModel>(await context.Tasks
				.FindAsync(id));
		}

		public async Task DeleteAsync(TaskViewModel model)
		{
			var task = await context.Tasks.FindAsync(model.Id);

			context.Tasks.Remove(task!);

			await context.SaveChangesAsync();
		}
	}
}