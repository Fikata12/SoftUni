using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Data.Seeding;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Web.Data
{
	public class TaskBoardAppDbContext : IdentityDbContext
	{
		public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Task> Tasks { get; set; } = null!;
		public DbSet<Board> Boards { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<Task>()
				.HasOne(t => t.Board)
				.WithMany(b => b.Tasks)
				.OnDelete(DeleteBehavior.Restrict);

			var userSeeder = new IdentityUserSeeder();
			var boardSeeder = new BoardSeeder();
			var taskSeeder = new TaskSeeder();

			var user = userSeeder.GenerateUser();
			builder
				.Entity<IdentityUser>()
				.HasData(user);

			builder
				.Entity<Board>()
				.HasData(boardSeeder.GenerateBoards());

			builder
				.Entity<Task>()
				.HasData(taskSeeder.GenerateTasks(user));

			base.OnModelCreating(builder);
		}
	}
}