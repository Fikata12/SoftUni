﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
