using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> box = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int capacityRack = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int sum = 0;
            while (box.Count > 0)
            {
                if (sum + box.Peek() <= capacityRack)
                {
                    sum += box.Pop();
                }
                else if (sum + box.Peek() > capacityRack)
                {
                    rackCounter++;
                    sum = 0;
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
