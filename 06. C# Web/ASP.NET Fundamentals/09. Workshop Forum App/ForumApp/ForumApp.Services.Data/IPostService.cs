using ForumApp.Web.ViewModels.Post;

namespace ForumApp.Services.Data
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> AllAsync();

        Task AddAsync(PostFormModel model);

        Task<PostFormModel> GetByIdAsync(int id);

        Task EditAsync(int id, PostFormModel model);

        Task RemoveByIdAsync(int id);
    }
}
