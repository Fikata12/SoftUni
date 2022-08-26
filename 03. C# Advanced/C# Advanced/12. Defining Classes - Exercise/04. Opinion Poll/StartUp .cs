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
            List<Person> peopleOver30 = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string name = input.Split()[0];
                int age = int.Parse(input.Split()[1]);
                if (age > 30)
                {
                    peopleOver30.Add(new Person(name, age));
                }
            }

            foreach (var person in peopleOver30.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
