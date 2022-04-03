using System;
using System.Linq;

namespace T4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] givenRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = givenRow[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd.Length != 5 || givenCmd[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRow = int.Parse(givenCmd[1]);
                    int firstCol = int.Parse(givenCmd[2]);
                    int secondRow = int.Parse(givenCmd[3]);
                    int secondCol = int.Parse(givenCmd[4]);
                    if (IsRowValid(firstRow, matrix) && IsRowValid(secondRow, matrix) && IsColValid(firstCol, matrix) && IsColValid(secondCol, matrix))
                    {
                        string firstCell = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = firstCell;
                        PrintTheMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static bool IsColValid(int col, string[,] matrix)
        {
            return col >= 0 && col < matrix.GetLength(1);
        }

        private static bool IsRowValid(int row, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0);
        }

        private static void PrintTheMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
