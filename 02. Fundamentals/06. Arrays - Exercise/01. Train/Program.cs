﻿using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
                sum += train[i];
            }
            Console.WriteLine(String.Join(' ', train));
            Console.WriteLine(sum);
        }
    }
}