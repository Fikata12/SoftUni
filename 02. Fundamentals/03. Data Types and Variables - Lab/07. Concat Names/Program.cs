﻿using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            string delimiter = Console.ReadLine();
            Console.WriteLine($"{name}{delimiter}{surname}");
        }
    }
}
