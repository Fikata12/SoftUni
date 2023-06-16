using Humanizer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Library.Data.Models
{
	public class Book
	{
        public Book()
        {
			UsersBooks = new HashSet<IdentityUserBook>();
		}
        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(50)]
		public string Author { get; set; } = null!;

		[Required]
		[MaxLength(5000)]
		public string Description { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public decimal Rating { get; set; }

		[Required]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }


		public Category Category { get; set; } = null!;
		public ICollection<IdentityUserBook> UsersBooks { get; set; } = null!;
	}
}