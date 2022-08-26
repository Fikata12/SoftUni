using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
        public int Food { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public void BuyFood()
        {
            Food += 10;
        }
    }
}
