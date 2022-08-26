using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end") 
            {
                string[] cmd = command.Split().ToArray();
                string commandPart1 = cmd[0];
                
     
                else if (commandPart1 == "Add")
                {
                    string commandPart2 = cmd[1];
                    numbers.Add(int.Parse(commandPart2));
                }
                else if (commandPart1 == "Remove")
                {
                    string commandPart2 = cmd[1];
                    numbers.Remove(int.Parse(commandPart2));
                }
                else if (commandPart1 == "RemoveAt")
                {
                    string commandPart2 = cmd[1];
                    numbers.RemoveAt(int.Parse(commandPart2));
                }
                else if (commandPart1 == "Insert")
                {
                    string commandPart2 = cmd[1];
                    numbers.Insert(int.Parse(cmd[2]), int.Parse(commandPart2));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
