using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(name);
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
