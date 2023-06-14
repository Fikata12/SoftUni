using AutoMapper;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Services.Mapping
{
	public class TaskBoardAppProfile : Profile
	{
        public TaskBoardAppProfile()
        {
            CreateMap<Task, TaskViewModel>()
                .ForMember(d => d.Owner, opt => opt.MapFrom(s => s.Owner.UserName));

            CreateMap<Board, AllBoardViewModel>();

            CreateMap<TaskFormModel, Task>()
				.ForMember(d => d.CreatedOn, opt => opt.MapFrom(s => DateTime.Now));

			CreateMap<Board, SelectBoardViewModel>();

            CreateMap<Task, TaskDetailsViewModel>()
				.ForMember(d => d.Owner, opt => opt.MapFrom(s => s.Owner.UserName))
                .ForMember(d => d.Board, opt => opt.MapFrom(s => s.Board.Name))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(s => s.CreatedOn.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<Task, TaskFormModel>();
		}
	}
}