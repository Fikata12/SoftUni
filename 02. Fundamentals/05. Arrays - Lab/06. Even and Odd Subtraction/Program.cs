﻿using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sumEven += number;
                }
                else
                {
                    sumOdd += number;
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
