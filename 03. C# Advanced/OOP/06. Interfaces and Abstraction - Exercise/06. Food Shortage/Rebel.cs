using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public string Group{ get; }
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
