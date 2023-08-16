using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Common.ValidationConstants.Ad;

namespace SoftUniBazar.Data.Models
{
	public class Ad
	{
        public Ad()
        {
			AdsBuyers = new List<AdBuyer>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(DescriptionMinLength)]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		[ForeignKey(nameof(Owner))]
		public string OwnerId { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		public IdentityUser Owner { get; set; } = null!;
		public Category Category { get; set; } = null!;
		public ICollection<AdBuyer> AdsBuyers { get; set; }
	}
}
