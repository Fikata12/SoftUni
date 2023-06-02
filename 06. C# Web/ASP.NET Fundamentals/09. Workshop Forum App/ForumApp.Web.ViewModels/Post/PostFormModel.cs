using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.DataConstants.Post;

namespace ForumApp.Web.ViewModels.Post
{
	public class PostFormModel
	{
		[Required]
		[MinLength(TitleMinLength)]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;
		[Required]
		[MinLength(ContentMinLength)]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;
	}
}
