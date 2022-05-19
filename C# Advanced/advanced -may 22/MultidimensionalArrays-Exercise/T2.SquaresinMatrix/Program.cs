using System;
using System.Linq;

namespace T2.SquaresinMatrix
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

            char[,] matrix = new char[row, col];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] givenRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = givenRow[cols];
                }
            }

            int count = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    if (AreCharsEqual(matrix, rows, cols))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }
        static bool AreCharsEqual(char[,] matrix, int rows, int cols)
        {
            return matrix[rows, cols] == matrix[rows, cols + 1] && matrix[rows, cols] == matrix[rows + 1, cols] && matrix[rows, cols] == matrix[rows + 1, cols + 1];
        }
    }
}
