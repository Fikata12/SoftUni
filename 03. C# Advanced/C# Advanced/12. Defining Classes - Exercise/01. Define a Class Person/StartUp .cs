﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person person = new Person();
            Person person2 = new Person()
            {
                Age = 16,
                Name = "Philip"
            };
        }
    }
}
