using System;
using System.Linq;

namespace T9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[n, n];
            int coalCount = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'c')
                    {
                        coalCount++;
                    }
                    if (input[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            foreach (var item in commands)
            {
                if (item == "up")
                {
                    if (IsIndexValid(matrix, startRow - 1, startCol))
                    {
                        startRow--;
                    }
                }
                else if (item == "right")
                {
                    if (IsIndexValid(matrix, startRow, startCol + 1))
                    {
                        startCol++; ;
                    }
                }
                else if (item == "left")
                {
                    if (IsIndexValid(matrix, startRow, startCol - 1))
                    {
                        startCol--;
                    }
                }
                else if (item == "down")
                {
                    if (IsIndexValid(matrix, startRow + 1, startCol))
                    {
                        startRow++;
                    }
                }
                IsExitCharacter(matrix, startRow, startCol);
                if (matrix[startRow, startCol] == 'c')
                {
                    matrix[startRow, startCol] = '*';
                    coalCount--;
                    if (coalCount <= 0)
                    {
                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalCount} coals left. ({startRow}, {startCol})");
        }

        private static bool IsIndexValid(char[,] matrix, int startRow, int startCol)
        {
            return startRow >= 0
                && startCol >= 0
                && startRow < matrix.GetLength(0)
                && startCol < matrix.GetLength(1);
        }
        private static void IsExitCharacter(char[,] matrix, int startRow, int startCol)
        {
            if (matrix[startRow, startCol] == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                Environment.Exit(0);
            }
        }
    }
}
