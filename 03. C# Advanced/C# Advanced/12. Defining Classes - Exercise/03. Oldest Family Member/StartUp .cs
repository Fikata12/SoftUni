using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                family.AddMember(new Person(input[0], int.Parse(input[1])));
            }
            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
