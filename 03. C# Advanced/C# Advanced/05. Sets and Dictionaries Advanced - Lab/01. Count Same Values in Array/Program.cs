using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> valuesAndOcc = new Dictionary<double, int>();
            foreach (double value in values)
            {
                if (valuesAndOcc.ContainsKey(value))
                {
                    valuesAndOcc[value]++;
                }
                else
                {
                    valuesAndOcc.Add(value, 1);
                }
            }
            foreach (var item in valuesAndOcc)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
