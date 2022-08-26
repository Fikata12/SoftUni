using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> numbers = new HashSet<int>();
            int counter = 1;
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (numbers.Contains(input))
                {
                    num = input;
                    counter++;
                }
                else
                {
                    numbers.Add(input);
                }
            }
            if (counter % 2 == 0)
            {
                Console.WriteLine(num);
            }
        }
    }
}
