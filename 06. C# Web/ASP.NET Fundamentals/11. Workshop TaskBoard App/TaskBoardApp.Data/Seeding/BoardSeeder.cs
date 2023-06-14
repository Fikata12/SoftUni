using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Seeding
{
	internal class BoardSeeder
	{
		public ICollection<Board> GenerateBoards()
		{
			return new List<Board>()
			{
				new Board
				{
					Id = 1,
					Name = "Open"
				},
				new Board
				{
					Id = 2,
					Name = "In Progress"
				},
				new Board
				{
					  Id = 3,
					Name = "Done"
				}
			};
		}
	}
}
