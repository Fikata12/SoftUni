using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryAddViewModel>? Categories { get; set; } = null!;
    }
}
