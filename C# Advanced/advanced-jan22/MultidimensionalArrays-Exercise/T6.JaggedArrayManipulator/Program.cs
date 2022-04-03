using System;
using System.Linq;

namespace T6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (long row = 0; row < rows; row++)
            {
                double[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[row] = currRow;
            }

            for (long row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    MultiplyByTwo(matrix, row);
                }
                else
                {
                    DivideByTwo(matrix, row);
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = givenCmd[0];
                long row = long.Parse(givenCmd[1]);
                long col = long.Parse(givenCmd[2]);
                long value = long.Parse(givenCmd[3]);

                if (action == "Add")
                {
                    if (IsIndexValid(row, col, matrix))
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (action == "Subtract")
                {
                    if (IsIndexValid(row, col, matrix))
                    {
                        matrix[row][col] -= value;
                    }
                }
                command = Console.ReadLine();
            }
            PrintTheMatrix(matrix);
        }

        private static bool IsIndexValid(long row, long col, double[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length;
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

        private static void DivideByTwo(double[][] matrix, long row)
        {
            for (long currRow = row; currRow <= row + 1; currRow++)
            {
                for (long col = 0; col < matrix[currRow].Length; col++)
                {
                    matrix[currRow][col] /= 2;
                }
            }
        }

        private static void MultiplyByTwo(double[][] matrix, long row)
        {
            for (long currRow = row; currRow <= row + 1; currRow++)
            {
                for (long col = 0; col < matrix[currRow].Length; col++)
                {
                    matrix[currRow][col] *= 2;
                }
            }
        }
    }
}
