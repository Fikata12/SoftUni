using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.Ad;

namespace SoftUniBazar.Models
{
    public class AdFormModel
    {
        public AdFormModel()
        {
            Categories = new List<CategoryViewModel>();
        }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Price { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
