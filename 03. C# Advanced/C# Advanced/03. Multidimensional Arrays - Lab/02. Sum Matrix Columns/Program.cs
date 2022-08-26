using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];
            int[] sumCols = new int[cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                    sumCols[col] += colElements[col];
                }
            }
            foreach (int sum in sumCols)
            {
                Console.WriteLine(sum);
            }
        }
    }
}