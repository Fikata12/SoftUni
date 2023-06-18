using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Type;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        public ICollection<Event> Events { get; set; } = null!;
    }
}