﻿using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public int ScoredGoals { get; set; } 
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public Game Game { get; set; } = null!;
        public Player Player { get; set; } = null!;
    }
}
