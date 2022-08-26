using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;
            int sum = 0;
            bool areEqual = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    sum += a[i];
                }
                else
                {
                    areEqual = false;
                    index = i;
                    break;
                }
            }
            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
        }
    }
}
