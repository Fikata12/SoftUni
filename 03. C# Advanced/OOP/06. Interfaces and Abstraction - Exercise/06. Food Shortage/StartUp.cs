using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> citizensAndRebels = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputToArray = input.Split().ToArray();
                if (inputToArray.Length == 3)
                {
                    citizensAndRebels.Add(new Rebel(inputToArray[0], int.Parse(inputToArray[1]), inputToArray[2]));
                }
                else
                {
                    citizensAndRebels.Add(new Citizen(inputToArray[0], int.Parse(inputToArray[1]), inputToArray[2], inputToArray[3]));
                }
            }
            string name = Console.ReadLine();
            while (name != "End")
            {
                IBuyer buyer = citizensAndRebels.FirstOrDefault(c => c.Name == name);
                if (citizensAndRebels.Contains(citizensAndRebels.FirstOrDefault(c => c.Name == name)))
                {
                    buyer.BuyFood();
                }
                name = Console.ReadLine();
            }
            int totalAmountOfFood = 0;
            citizensAndRebels.ForEach(c => totalAmountOfFood += c.Food);
            Console.WriteLine(totalAmountOfFood);
        }
    }
}
