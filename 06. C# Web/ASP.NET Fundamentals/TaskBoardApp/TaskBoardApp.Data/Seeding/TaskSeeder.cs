using Microsoft.AspNetCore.Identity;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Seeding
{
	internal class TaskSeeder
	{
		public ICollection<Task> GenerateTasks(IdentityUser user)
		{
			return new List<Task>()
			{
				new Task
				{
					Id = 1,
					Title = "Improve CSS files",
					Description = "Implement better styling for all public pages",
					CreatedOn = DateTime.Now.AddDays(-200),
					OwnerId = user.Id,
					BoardId = 1
				},
				new Task
				{
					Id = 2,
					Title = "Android Client App",
					Description = "Create Android client app for the TaskBoard RESTful API",
					CreatedOn = DateTime.Now.AddMonths(-5),
					OwnerId = user.Id,
					BoardId = 1
				},
				new Task
				{
					Id = 3,
					Title = "Dektop Client App",
					Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
					CreatedOn = DateTime.Now.AddMonths(-1),
					OwnerId = user.Id,
					BoardId = 2
				},
				new Task
				{
					Id = 4,
					Title = "Create Tasks",
					Description = "Implement [Create Task] for adding new tasks",
					CreatedOn = DateTime.Now.AddYears(-1),
					OwnerId = user.Id,
					BoardId = 3
				}
			};
		}
	}
}
