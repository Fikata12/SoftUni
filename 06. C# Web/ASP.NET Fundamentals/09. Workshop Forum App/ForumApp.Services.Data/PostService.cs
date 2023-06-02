using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.Web.ViewModels.Post;

namespace ForumApp.Services.Data
{
	public class PostService : IPostService
	{
		private readonly ForumAppDbContext context;
		private readonly IMapper mapper;
		public PostService(ForumAppDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<PostViewModel>> AllAsync()
		{
			return await context.Posts
				.AsNoTracking()
				.ProjectTo<PostViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}
		public async Task<PostFormModel> GetByIdAsync(int id)
		{
			var post = await context.Posts.FindAsync(id);

			return mapper.Map<PostFormModel>(post);
		}
		public async Task AddAsync(PostFormModel model)
		{
			await context.AddAsync(mapper.Map<Post>(model));

			await context.SaveChangesAsync();
		}
		public async Task EditAsync(int id, PostFormModel model)
		{
			var post = await context.Posts.FindAsync(id);

			post.Title = model.Title;
			post.Content = model.Content;

			await context.SaveChangesAsync();
		}

		public async Task RemoveByIdAsync(int id)
		{
			var post = context.Posts.Find(id)!;
			context.Remove(post);

			await context.SaveChangesAsync();
		}
	}
}
