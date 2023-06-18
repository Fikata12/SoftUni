using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Data.Models
{
    public class Event
    {
        public Event()
        {
            EventsParticipants = new HashSet<EventParticipant>();
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
        [ForeignKey("Organiser")]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }


        public IdentityUser Organiser { get; set; } = null!;
        public Type Type { get; set; } = null!;
        public ICollection<EventParticipant> EventsParticipants { get; set; } = null!;
    }
}
