using System;
using System.Linq;

namespace T02.Garden
{
    internal class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            matrix = new int[rows, columns];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] givenCmd = command.Split(" ").Select(int.Parse).ToArray();
                int row = givenCmd[0];
                int col = givenCmd[1];

                if (IsIndexValid(row, col))
                {
                    IncreaseElements(row, col);
                }
                else
                    Console.WriteLine($"Invalid coordinates.");

                command = Console.ReadLine();
            }
            PrintTheMatrix();
        }

        private static void IncreaseElements(int row, int col)
        {
            matrix[row, col]++;
            for (int currRow = row; currRow < row + 1; currRow++)
            {
                for (int currCol = 0; currCol < matrix.GetLength(1); currCol++)
                {
                    if (currRow == row && currCol == col)
                        continue;
                    matrix[currRow, currCol]++;
                }
            }
            for (int currRow = 0; currRow < matrix.GetLength(0); currRow++)
            {
                for (int currCol = col; currCol < col + 1; currCol++)
                {
                    if (currRow == row && currCol == col)
                        continue;
                    matrix[currRow, currCol]++;
                }
            }
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
        private static void PrintTheMatrix()
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
