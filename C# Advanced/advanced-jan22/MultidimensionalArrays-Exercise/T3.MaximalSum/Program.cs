using System;
using System.Linq;

namespace T3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int highestRow = 0;
            int highestCol = 0;
            int maxValue = int.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currSum = 0;
                    for (int currRow = row; currRow < row + 3; currRow++)
                    {
                        for (int currCol = col; currCol < col + 3; currCol++)
                        {
                            currSum += matrix[currRow, currCol];
                        }
                    }
                    if (currSum > maxValue)
                    {
                        maxValue = currSum;
                        highestRow = row;
                        highestCol = col;
                    }
                }
            }

            //for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            //    {
            //        int currSum = 0;
            //        currSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
            //            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
            //            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
            //        if (currSum > maxValue)
            //        {
            //            maxValue = currSum;
            //            highestRow = row;
            //            highestCol = col;
            //        }
            //    }
            //}

            Console.WriteLine("Sum = " + maxValue);
            for (int row = highestRow; row <= highestRow + 2; row++)
            {
                for (int col = highestCol; col <= highestCol + 2; col++)
                {
                    if (col == highestCol + 2)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
