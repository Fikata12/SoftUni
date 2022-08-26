using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counter = 0;
            Queue<string> jam = new Queue<string>();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (jam.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{jam.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    jam.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
