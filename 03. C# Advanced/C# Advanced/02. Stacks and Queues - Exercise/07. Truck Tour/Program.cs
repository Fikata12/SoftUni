using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(input);
            }
            int startIndex = 0;
            bool IsComplete = false;
            while (IsComplete == false)
            {
                int totalLiters = 0;
                foreach (int[] pump in queue)
                {
                    int liters = pump[0];
                    int distance = pump[1];
                    totalLiters += liters; 
                    if (totalLiters - distance >= 0)
                    {
                        totalLiters -= distance;
                        IsComplete = true;
                    }
                    else
                    {
                        startIndex++;
                        queue.Enqueue(queue.Dequeue());
                        IsComplete = false;
                        break;
                    }
                }
            }
            Console.WriteLine(startIndex);
        }
    }
}
