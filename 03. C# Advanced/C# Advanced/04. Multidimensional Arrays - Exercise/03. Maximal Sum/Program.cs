using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            int topSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row,     col] + matrix[row,     col + 1] + matrix[row,     col + 2] 
                                   + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                   + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > topSum)
                    {
                        topSum = currentSum;
                    }
                }
            }
            Console.WriteLine($"Sum = {topSum}");
            bool topSumMatrixPrinted = false;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row,     col] + matrix[row,     col + 1] + matrix[row,     col + 2]
                                   + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                   + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum == topSum)
                    {
                        for (int i = row; i <= row + 2; i++)
                        {
                            for (int j = col; j <= col + 2; j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        topSumMatrixPrinted = true;
                    }
                    if (topSumMatrixPrinted)
                    {
                        break;
                    }
                }
                if (topSumMatrixPrinted)
                {
                    break;
                }
            }
        }
    }
}
