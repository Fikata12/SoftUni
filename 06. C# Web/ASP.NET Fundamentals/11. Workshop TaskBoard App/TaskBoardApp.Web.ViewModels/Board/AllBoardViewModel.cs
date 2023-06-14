using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.ViewModels.Board
{
    public class AllBoardViewModel
    {
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
	}
}