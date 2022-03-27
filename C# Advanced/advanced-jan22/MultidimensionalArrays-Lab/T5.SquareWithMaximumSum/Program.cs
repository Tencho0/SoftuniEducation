using System;
using System.Linq;

namespace T5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biggestSquareRows = 2;
            int biggestSquareColumns = 2;

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (row + biggestSquareRows - 1 < rows && col + biggestSquareColumns-1 < columns)
                    {
                        int sum = 0;
                        //matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        for (int currRow = row; currRow < row+ biggestSquareRows; currRow++)
                        {
                            for (int currCol = col; currCol < col + biggestSquareColumns; currCol++)
                            {
                                sum += matrix[currRow, currCol];
                            }
                        }
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxRowIndex = row;
                            maxColIndex = col;
                        }
                    }
                }
            }

            for (int row = maxRowIndex; row < maxRowIndex+ biggestSquareRows; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + biggestSquareColumns; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
