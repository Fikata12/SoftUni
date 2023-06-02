using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    public class PostSeeder
    {
        public ICollection<Post> GeneratePosts()
        {
            ICollection<Post> posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Post No.1",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique."
                },
                new Post
                {
                    Id = 2,
                    Title = "Post No.2",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique."
                },
                new Post
                {
                    Id = 3,
                    Title = "Post No.3",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique."
                }
            };
            return posts;
        }
    }
}
