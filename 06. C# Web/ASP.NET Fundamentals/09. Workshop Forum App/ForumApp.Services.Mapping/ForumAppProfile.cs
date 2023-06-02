using AutoMapper;
using ForumApp.Data.Models;
using ForumApp.Web.ViewModels.Post;

namespace ForumApp.Services.Mapping
{
    public class ForumAppProfile : Profile
    {
        public ForumAppProfile()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostFormModel, Post>();
            CreateMap<Post, PostFormModel>();
		}
    }
}