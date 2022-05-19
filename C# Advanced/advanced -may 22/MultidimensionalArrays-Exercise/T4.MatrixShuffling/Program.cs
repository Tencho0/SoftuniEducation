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
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd.Length == 5 && givenCmd[0] == "swap")
                {
                    SwapElements(matrix, givenCmd);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintTheMaxtrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void SwapElements(string[,] matrix, string[] givenCmd)
        {
            int row1 = int.Parse(givenCmd[1]);
            int col1 = int.Parse(givenCmd[2]);
            int row2 = int.Parse(givenCmd[3]);
            int col2 = int.Parse(givenCmd[4]);

            if (row1 >= 0 &&
                row2 >= 0 &&
                col1 >= 0 &&
                col2 >= 0 &&
                matrix.GetLength(0) > row1 &&
                matrix.GetLength(0) > row2 &&
                matrix.GetLength(1) > col1 &&
                matrix.GetLength(1) > col2)
            {
                string firstElement = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = firstElement;
                PrintTheMaxtrix(matrix);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
