using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam
{
    public class Player
    {
        private string name;
        private Stats stats;
        public string Name
        {
            get { return name; }
            private set { name = Validator.NameValidator(value); }
        }
        public Stats Stats
        {
            get { return stats; }
            private set { stats = value; }
        }
        public double SkillLevel
        {
            get { return (Stats.Endurance + Stats.Dribble + Stats.Passing + Stats.Shooting + Stats.Sprint) / 5.0; }
        }
        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }
    }
}
