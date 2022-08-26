using System;
using System.Linq;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            long nLines = long.Parse(Console.ReadLine());

            for (int i = 0; i < nLines; i++)
            {
                long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();
                if (array[0] > array[1])
                {
                    long newValue = Math.Abs(array[0]);
                    long sum = 0;
                    while (newValue > 0)
                    {
                        sum += newValue % 10;   
                        newValue /= 10;
                    }
                    Console.WriteLine(sum);
                }
                else
                {
                    long newValue = Math.Abs(array[1]);
                    long sum = 0;
                    while (newValue > 0)
                    {
                        sum += newValue % 10;
                        newValue /= 10;
                    }
                     Console.WriteLine(sum);
                }
                Array.Clear(array, 0, array.Length);
            }
        }
    }
}
