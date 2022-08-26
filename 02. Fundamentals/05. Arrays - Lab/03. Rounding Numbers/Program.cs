using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{(decimal)array[i]} => {Math.Round((decimal)array[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}