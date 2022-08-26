using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        [MyRequired]
        public string Name { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
