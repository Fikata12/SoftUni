using System.ComponentModel.DataAnnotations;

using static ForumApp.Common.DataConstants.Post;

namespace ForumApp.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}