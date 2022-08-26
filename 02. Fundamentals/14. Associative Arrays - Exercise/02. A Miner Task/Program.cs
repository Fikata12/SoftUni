using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            Dictionary<string, int> mine = new Dictionary<string, int>();
            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!mine.ContainsKey(resource))
                {
                    mine.Add(resource, quantity);
                }
                else
                {
                    mine[resource] += quantity;
                }
                resource = Console.ReadLine();
            }
            foreach (var resource2 in mine)
            {
                Console.WriteLine($"{resource2.Key} -> {resource2.Value}");
            }
        }
    }
}
