using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
	public class AdBuyer
	{
		[ForeignKey(nameof(Buyer))]
		public string BuyerId { get; set; } = null!;


		[ForeignKey(nameof(Ad))]
		public int AdId { get; set; }

		public IdentityUser Buyer { get; set; } = null!;
		public Ad Ad { get; set; } = null!;
	}
}
