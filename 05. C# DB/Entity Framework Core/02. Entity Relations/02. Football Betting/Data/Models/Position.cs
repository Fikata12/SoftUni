using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public ICollection<Player> Players { get; set; } = null!;
    }
}
