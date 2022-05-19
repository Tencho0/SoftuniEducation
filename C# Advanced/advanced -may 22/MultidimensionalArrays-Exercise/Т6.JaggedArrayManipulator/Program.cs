using System;
using System.Linq;

namespace Т6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            FillTheMatrix(matrix, n);

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                long row = long.Parse(givenCmd[1]);
                long col = long.Parse(givenCmd[2]);
                long value = long.Parse(givenCmd[3]);

                if (AreIndiciesValid(row, col, matrix))
                {
                    if (action == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (action == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            PrintTheMatrix(matrix);
        }

        private static void FillTheMatrix(double[][] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[i] = row;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }
        }

        private static void PrintTheMatrix(double[][] matrix)
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
        static bool AreIndiciesValid(long row, long col, double[][] matrix)
        {
            return row >= 0 &&
                col >= 0 &&
                matrix.GetLength(0) > row &&
                matrix[row].Length > col;
        }
    }
}
