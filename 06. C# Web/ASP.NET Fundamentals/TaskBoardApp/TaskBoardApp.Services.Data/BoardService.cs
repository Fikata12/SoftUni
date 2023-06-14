using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Services.Data.Contracts;
using TaskBoardApp.Web.Data;
using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Services.Data
{
    public class BoardService : IBoardService
	{
		private readonly TaskBoardAppDbContext context;
		private readonly IMapper mapper;
		public BoardService(TaskBoardAppDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<AllBoardViewModel>> AllAsync()
		{
			return await context.Boards
				.AsNoTracking()
				.ProjectTo<AllBoardViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

        public async Task<IEnumerable<SelectBoardViewModel>> AllForSelectAsync()
        {
			return await context.Boards
				.AsNoTracking()
				.ProjectTo<SelectBoardViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
        }
    }
}
