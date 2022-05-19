using System;
using System.Linq;

namespace T3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            (int row, int col) = (size[0], size[1]);

            int[,] matrix = new int[row, col];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] givenRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = givenRow[cols];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    int currSum =
                        matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2] +
                        matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                        matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxSumRow = rows;
                        maxSumCol = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int rows = maxSumRow; rows < maxSumRow + 3; rows++)
            {
                for (int cols = maxSumCol; cols < maxSumCol + 3; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
