using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public int SquadNumber { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public bool IsInjured { get; set; }
        public Team Team { get; set; } = null!;
        public Position Position { get; set; } = null!;
        public ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
    }
}
