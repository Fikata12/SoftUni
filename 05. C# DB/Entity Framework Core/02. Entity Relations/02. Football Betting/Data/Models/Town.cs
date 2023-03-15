using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key] 
        public int TownId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public ICollection<Team> Teams { get; set; } = null!;
        public Country Country { get; set; } = null!;

    }
}
