using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.Category;

namespace SoftUniBazar.Data.Models
{
	public class Category
	{
        public Category()
        {
			Ads = new List<Ad>();
        }
        [Key]
		public int Id { get; set; }

		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public ICollection<Ad> Ads { get; set; }
	}
}