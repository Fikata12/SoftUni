using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRotations; i++)
            {
                int firstElement = array[0];
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = firstElement;
            }
            Console.WriteLine(String.Join(' ', array));
        }
    }
}
