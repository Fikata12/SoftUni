using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsAndGrades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (studentsAndGrades.ContainsKey(input[0]))
                {
                    studentsAndGrades[input[0]].Add(decimal.Parse(input[1]));
                }
                else
                {
                    studentsAndGrades.Add(input[0], new List<decimal>());
                    studentsAndGrades[input[0]].Add(decimal.Parse(input[1]));
                }
            }
            foreach (var item in studentsAndGrades)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {item.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
