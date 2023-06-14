using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Common.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Board))]
		public int BoardId { get; set; }

		[ForeignKey(nameof(Owner))]
		public string OwnerId { get; set; } = null!;

		public IdentityUser Owner { get; set; } = null!;
		public Board Board { get; set; } = null!;
	}
}