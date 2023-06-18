using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Models
{
	public class EventViewModel
	{
		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(DescriptionMinLength)]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		public DateTime Start { get; set; }

		[Required]
		public DateTime End { get; set; }

		[Required]
		public int TypeId { get; set; }

		public string? OrganiserId { get; set; }

		public ICollection<TypeViewModel>? Types { get; set; } = null!;
	}
}
