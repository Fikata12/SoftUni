using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public int Endurance
        {
            get { return endurance; }
            set { endurance = StatValidator( value, nameof(Endurance)); }
        }
        public int Sprint
        {
            get { return sprint; }
            set { sprint = StatValidator(value, nameof(Endurance)); }
        }
        public int Dribble
        {
            get { return dribble; }
            set { dribble = StatValidator(value, nameof(Endurance)); }
        }
        public int Passing
        {
            get { return passing; }
            set { passing = StatValidator(value, nameof(Endurance)); }
        }
        public int Shooting
        {
            get { return shooting; }
            set { shooting = StatValidator(value, nameof(Endurance)); }
        }
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        private int StatValidator(int stat, string statName)
        {
            if (stat < 0 || stat > 100) 
            {
                throw new Exception($"{statName} should be between 0 and 100.");
            }
            else
            {
                return stat;
            }
        }
    }
}
