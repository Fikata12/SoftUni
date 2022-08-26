using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string Food { get; protected set; }
        public Animal(string name, string food)
        {
            Name = name;
            Food = food;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {Food}";
        }
    }
}
