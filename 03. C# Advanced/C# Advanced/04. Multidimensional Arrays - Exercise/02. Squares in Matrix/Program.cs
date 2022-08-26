using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            int number = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool areEqual = matrix[row, col] == matrix[row, col + 1] && matrix[row, col + 1] == matrix[row + 1, col] && matrix[row + 1, col] == matrix[row + 1, col + 1];
                    if (areEqual)
                    {
                        number++;
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}
