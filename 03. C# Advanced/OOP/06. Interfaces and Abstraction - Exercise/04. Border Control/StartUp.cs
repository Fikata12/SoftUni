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
            List<IIdentifiable> citizensAndRobots = new List<IIdentifiable>();
            while (input != "End")
            {
                string[] inputToArray = input.Split().ToArray();
                if (inputToArray.Length == 2)
                {
                    citizensAndRobots.Add(new Robot(inputToArray[0], inputToArray[1]));
                }
                else
                {
                    citizensAndRobots.Add(new Citizen(inputToArray[0], int.Parse(inputToArray[1]), inputToArray[2]));
                }
                input = Console.ReadLine();
            }
            string fakeIdValidator = Console.ReadLine();
            List<string> detainedIds = new List<string>();
            foreach (var citizen in citizensAndRobots)
            {
                if (citizen.Id.EndsWith(fakeIdValidator))
                {
                    detainedIds.Add(citizen.Id);
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, detainedIds));
        }
    }
}
