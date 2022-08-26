using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ").ToArray());
            while (queue.Count > 0)
            {
                List<string> fullCommand = Console.ReadLine().Split().ToList();
                string command = fullCommand[0];
                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                else if (command == "Add")
                {
                    fullCommand.Remove("Add");
                    string song = string.Join(' ', fullCommand);
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
