using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }      
        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public void AddPlayer(Person person)
        {
            if (person.Age >= 40)
            {
                reserveTeam.Add(person);
            }
            else
            {
                firstTeam.Add(person);
            }
        }
    }
}
