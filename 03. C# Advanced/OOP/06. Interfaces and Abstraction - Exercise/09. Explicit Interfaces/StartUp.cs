using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Citizen> citizens = new List<Citizen>();
            while (input != "End")
            {
                string[] inputToArray = input.Split();
                citizens.Add(new Citizen(inputToArray[0], int.Parse(inputToArray[2]), inputToArray[1]));
                input = Console.ReadLine();
            }
            foreach (var item in citizens)
            {
                IResident resident = item;
                IPerson person = item;
                Console.WriteLine(person.GetName());    
                Console.WriteLine(resident.GetName() + " " + person.GetName());
            }
        }
    }
}
