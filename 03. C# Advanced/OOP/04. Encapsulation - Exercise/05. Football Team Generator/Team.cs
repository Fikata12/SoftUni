using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public string Name
        {
            get { return name; }
            private set { name = Validator.NameValidator(value); }
        }
        public IReadOnlyCollection<Player> Players
        {
            get { return players; }
        }
        public double Rating
        {
            get
            {
                double rating = 0;
                players.ForEach(p => rating += p.SkillLevel);
                return Math.Round(rating);
            }
        }
        public Team(string name)
        {
            Name = name;
            this.players = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            if (players.Contains(player))
            {
                players.Remove(player);
            }
            else
            {
                throw new Exception($"Player {player.Name} is not in {Name} team.");
            }
        }
        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
