using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            bool found = false;
            char wantedSymbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (wantedSymbol == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"{wantedSymbol} does not occur in the matrix");
            }
        }
    }
}
