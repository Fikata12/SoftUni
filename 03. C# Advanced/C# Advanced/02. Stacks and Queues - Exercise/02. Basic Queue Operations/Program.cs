using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = array[0];
            int s = array[1];
            int x = array[2];
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            if (queue.Count == n)
            {
                for (int i = 0; i < s; i++)
                {
                    queue.Dequeue();
                }
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
