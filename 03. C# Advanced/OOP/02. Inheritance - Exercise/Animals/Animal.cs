using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{GetType().Name}" + Environment.NewLine +
                   $"{Name} {Age} {Gender}" + Environment.NewLine +
                   $"{ProduceSound()}";
        }
    }
}