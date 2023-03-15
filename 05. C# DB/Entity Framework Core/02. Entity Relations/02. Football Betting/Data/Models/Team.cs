using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(256)]
        public string LogoUrl { get; set; } = null!;
        [MaxLength(4)]
        public string Initials { get; set; } = null!;
        public decimal Budget { get; set; }
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Color PrimaryKitColor { get; set; } = null!;
        public Color SecondaryKitColor { get; set; } = null!;
        public Town Town { get; set; } = null!;

        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; } = null!;
        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; } = null!;
        public ICollection<Player> Players { get; set; } = null!;
    }
}