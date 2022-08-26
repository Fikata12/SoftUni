using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> citizensAndPets = new List<IBirthable>();
            while (input != "End")
            {
                string[] inputToArray = input.Split().ToArray();
                string cmd = inputToArray[0];
                if (cmd == "Citizen")
                {
                    citizensAndPets.Add(new Citizen(inputToArray[1], int.Parse(inputToArray[2]), inputToArray[3], inputToArray[4]));
                }
                else if (cmd == "Pet")
                {
                    citizensAndPets.Add(new Pet(inputToArray[1], inputToArray[2]));
                }
                input = Console.ReadLine();
            }
            string ageValidator = Console.ReadLine();
            foreach (var birthable in citizensAndPets)
            {
                if (birthable.Birthdate.EndsWith(ageValidator))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
