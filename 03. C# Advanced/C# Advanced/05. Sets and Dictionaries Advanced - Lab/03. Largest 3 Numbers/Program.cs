using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] sortedInput = input.OrderByDescending(x => x).ToArray();
            int counter = 0;
            foreach (int item in sortedInput)
            {
                counter++;
                if (counter <= 3)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
