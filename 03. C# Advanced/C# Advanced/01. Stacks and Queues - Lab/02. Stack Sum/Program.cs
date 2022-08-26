using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string cmd = Console.ReadLine().ToLower();
            Stack<int> stack = new Stack<int>(integers);
            while (cmd != "end")
            {
                string[] numbers = cmd.Split().ToArray();
                if (numbers[0] == "add")
                {                  
                    stack.Push(int.Parse(numbers[1]));
                    stack.Push(int.Parse(numbers[2]));
                }
                else if (numbers[0] == "remove" && stack.Count >= int.Parse(numbers[1]))
                {
                    for (int i = 0; i < int.Parse(numbers[1]); i++)
                    {
                        stack.Pop();
                    }
                }
                cmd = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
