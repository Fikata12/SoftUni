using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
	public class Board
	{
        public Board()
        {
			Tasks = new HashSet<Task>();
        }

        [Key]
		public int Id { get; set; }

		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;


		public ICollection<Task> Tasks { get; set; } = null!;
	}
}