using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Services.Data.Contracts
{
	public interface IBoardService
	{
		Task<IEnumerable<AllBoardViewModel>> AllAsync();
		Task<IEnumerable<SelectBoardViewModel>> AllForSelectAsync();
	}
}
