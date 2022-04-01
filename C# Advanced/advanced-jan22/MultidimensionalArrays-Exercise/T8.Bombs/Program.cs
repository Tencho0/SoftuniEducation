using System;
using System.Linq;

namespace T8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            string[] bombs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombs)
            {
                int[] currCoordinates = bomb
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = currCoordinates[0];
                int bombCol = currCoordinates[1];
                int bombPower = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] > 0)
                {
                    // OverBomb
                    if (IsIndexValid(matrix, bombRow - 1, bombCol))
                    {
                        matrix[bombRow - 1, bombCol] -= bombPower;
                    }

                    // OverBombLeftDiagonal
                    if (IsIndexValid(matrix, bombRow - 1, bombCol - 1))
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bombPower;
                    }

                    // OverBombRigtDiagonal
                    if (IsIndexValid(matrix, bombRow - 1, bombCol + 1))
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bombPower;
                    }

                    // LeftToTheBomb
                    if (IsIndexValid(matrix, bombRow, bombCol - 1))
                    {
                        matrix[bombRow, bombCol - 1] -= bombPower;
                    }

                    // RightToTheBomb
                    if (IsIndexValid(matrix, bombRow, bombCol + 1))
                    {
                        matrix[bombRow, bombCol + 1] -= bombPower;
                    }

                    // UnderBomb
                    if (IsIndexValid(matrix, bombRow + 1, bombCol))
                    {
                        matrix[bombRow + 1, bombCol] -= bombPower;
                    }

                    // UnderBombLeftDiagonal
                    if (IsIndexValid(matrix, bombRow + 1, bombCol - 1))
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bombPower;
                    }

                    // UnderBombRightDiagonal
                    if (IsIndexValid(matrix, bombRow + 1, bombCol + 1))
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bombPower;
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }
            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsIndexValid(int[,] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombCol >= 0 && matrix.GetLength(0) > bombRow && matrix.GetLength(1) > bombCol && matrix[bombRow, bombCol] > 0;
        }
    }
}
