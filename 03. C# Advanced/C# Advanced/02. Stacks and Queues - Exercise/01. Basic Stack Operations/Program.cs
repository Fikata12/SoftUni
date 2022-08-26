using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = array[0];
            int s = array[1];
            int x = array[2];
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            if (stack.Count == n)
            {
                for (int i = 0; i < s; i++)
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}