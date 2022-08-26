using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }
            foreach (var kvp in students.Where(x => x.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
