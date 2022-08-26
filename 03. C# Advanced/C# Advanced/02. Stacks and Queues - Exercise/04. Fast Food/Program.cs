using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(orders.Max());
            int count = orders.Count;
            for (int i = 0; i < count; i++)
            {
                if (n >= orders.Peek())
                {
                    n -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
        }
    }
}
