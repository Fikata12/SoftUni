using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }
        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            int oldestPersonIndex = int.MinValue;
            int oldestPersonAge = int.MinValue;
            for (int i = 0; i < People.Count; i++)
            {
                if (oldestPersonAge < People[i].Age)
                {
                    oldestPersonAge = People[i].Age;
                    oldestPersonIndex = i;
                }
            }
            return People[oldestPersonIndex];
        }
    }
}
