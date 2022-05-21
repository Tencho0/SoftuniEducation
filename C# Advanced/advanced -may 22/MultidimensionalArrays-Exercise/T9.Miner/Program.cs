using System;
using System.Linq;

namespace T9.Miner
{
    internal class Program
    {
        static char[,] matrix;
        static int coalCount;
        static int minerRow;
        static int minerCol;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            matrix = new char[n, n];
            FillTheMatrix();

            foreach (var currCmd in commands)
            {
                MoveTheMiner(currCmd);

                if (matrix[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
                else if (matrix[minerRow, minerCol] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    coalCount--;
                }

                if (coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            if (coalCount > 0) Console.WriteLine($"{coalCount} coals left. ({minerRow}, {minerCol})");
        }

        private static void MoveTheMiner(string currCmd)
        {
            if (currCmd == "left") if (IsIndexValid(minerRow, minerCol - 1)) minerCol--;
            if (currCmd == "right") if (IsIndexValid(minerRow, minerCol + 1)) minerCol++;
            if (currCmd == "up") if (IsIndexValid(minerRow - 1, minerCol)) minerRow--;
            if (currCmd == "down") if (IsIndexValid(minerRow + 1, minerCol)) minerRow++;

        }

        static void FillTheMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                    if (currRow[col] == 'c') coalCount++;
                    if (currRow[col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }
        }
        static bool IsIndexValid(int row, int col)
        {
            return row >= 0
                && col >= 0
                && row < matrix.GetLength(0)
                && col < matrix.GetLength(1);
        }
    }
}
