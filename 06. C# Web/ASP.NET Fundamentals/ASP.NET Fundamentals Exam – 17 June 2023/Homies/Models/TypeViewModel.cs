using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Type;

namespace Homies.Models
{
	public class TypeViewModel
	{
		public int Id { get; set; }

		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
