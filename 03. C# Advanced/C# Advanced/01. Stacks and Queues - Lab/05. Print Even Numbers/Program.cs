using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                     queue.Enqueue(queue.Dequeue());
                }
            }
            Console.WriteLine(String.Join(", ", queue));
        }
    }
}

