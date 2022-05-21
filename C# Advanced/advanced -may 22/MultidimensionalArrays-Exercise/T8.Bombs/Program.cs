using System;
using System.Collections.Generic;
using System.Linq;

namespace T8.Bombs
{
    internal class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            FillTheMatrix();

            string[] bombPairs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var currBomb in bombPairs)
            {
                int[] bombIndicies = currBomb
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                (int bombRow, int bombCol) = (bombIndicies[0], bombIndicies[1]);

                if (IsIndexValid(bombRow, bombCol))
                {
                    int bombPower = matrix[bombRow, bombCol];
                    matrix[bombRow, bombCol] = 0;

                    if (IsIndexValid(bombRow - 1, bombCol)) ReduceTheCell(bombRow - 1, bombCol, bombPower);
                    if (IsIndexValid(bombRow - 1, bombCol + 1)) ReduceTheCell(bombRow - 1, bombCol + 1, bombPower);
                    if (IsIndexValid(bombRow - 1, bombCol - 1)) ReduceTheCell(bombRow - 1, bombCol - 1, bombPower);
                    if (IsIndexValid(bombRow, bombCol - 1)) ReduceTheCell(bombRow, bombCol - 1, bombPower);
                    if (IsIndexValid(bombRow, bombCol + 1)) ReduceTheCell(bombRow, bombCol + 1, bombPower);
                    if (IsIndexValid(bombRow + 1, bombCol + 1)) ReduceTheCell(bombRow + 1, bombCol + 1, bombPower);
                    if (IsIndexValid(bombRow + 1, bombCol)) ReduceTheCell(bombRow + 1, bombCol, bombPower);
                    if (IsIndexValid(bombRow + 1, bombCol - 1)) ReduceTheCell(bombRow + 1, bombCol - 1, bombPower);
                }
            }

            PrintResult();
            PrintTheMatrix();
        }

        private static void PrintResult()
        {
            List<int> alivedCells = new List<int>();
            foreach (var item in matrix)
            {
                if (item > 0) alivedCells.Add(item);
            }
            Console.WriteLine($"Alive cells: {alivedCells.Count}");
            Console.WriteLine($"Sum: {alivedCells.Sum()}");
        }

        static bool IsIndexValid(int row, int col)
        {
            return row >= 0
                && col >= 0
                && row < matrix.GetLength(0)
                && col < matrix.GetLength(1)
                && matrix[row, col] > 0;
        }
        static void ReduceTheCell(int row, int col, int bombPower)
            => matrix[row, col] -= bombPower;
        static void FillTheMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
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
