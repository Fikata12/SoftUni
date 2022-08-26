using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = new int[colElements.Length];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = colElements[col];
                }
            }
            string[] input = Console.ReadLine().Split().ToArray();
            string command = input[0];
            while (command != "END")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);
                if ((jaggedArray.Length - 1 >= row && row >= 0) && (jaggedArray[row].Length - 1 >= col && col >= 0))
                {
                    if (command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                input = Console.ReadLine().Split().ToArray();
                command = input[0];
            }
            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
