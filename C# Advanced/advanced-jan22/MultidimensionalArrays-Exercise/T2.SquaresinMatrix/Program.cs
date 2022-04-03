using System;
using System.Linq;

namespace T2.SquaresinMatrix
{
    internal class Program
    {
        static char[,] matrix;
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new char[size[0], size[1]];
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) -1 ; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) -1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                    //char currLetter = matrix[row, col];
                    //// Right
                    //if (IsIndexValid(row, col + 1))
                    //{
                    //    if (matrix[row, col + 1] == currLetter)
                    //    {
                    //        if (IsIndexValid(row + 1, col))
                    //        {
                    //            // Down
                    //            if (matrix[row + 1, col] == currLetter)
                    //            {
                    //                if (IsIndexValid(row, col + 1))
                    //                {
                    //                    if (matrix[row + 1, col + 1] == currLetter)
                    //                    {
                    //                        count++;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            Console.WriteLine(count);
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
