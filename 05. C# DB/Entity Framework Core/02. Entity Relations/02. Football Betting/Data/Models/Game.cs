using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; } 
        public int HomeTeamGoals { get; set; } 
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public decimal HomeTeamBetRate { get; set; } 
        public decimal AwayTeamBetRate { get; set; }
        public decimal DrawBetRate { get; set; }
        public int Result { get; set; }
        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
        public ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
        public ICollection<Bet> Bets { get; set; } = null!;
    }
}
