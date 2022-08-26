using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int biggestNumToTheRight = int.MinValue;
            string output = string.Empty;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] > biggestNumToTheRight)
                {
                    output += array[i] + " ";
                    biggestNumToTheRight = array[i];                   
                }
            }
            int[] array2 = output.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Reverse(array2);
            Console.WriteLine(String.Join(' ', array2));
        }
    }
}
