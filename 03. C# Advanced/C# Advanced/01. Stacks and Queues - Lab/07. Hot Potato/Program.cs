using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();
            int tosses = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(names);
            while (queue.Count > 1)
            {
                for (int i = 0; i < tosses - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
