using System;
using System.Linq;

namespace T02.Bee
{
    internal class Program
    {
        static char[,] matrix;
        static int playerRow = -1;
        static int playerCol = -1;
        static int pollinatedFlowers = 0;
        static void Main(string[] args)
        {
            FillTheMatrix();
            bool gameOver = false;
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "up")
                {
                    Move(-1, 0, ref gameOver);
                }
                else if (command == "down")
                {
                    Move(1, 0, ref gameOver);
                }
                else if (command == "left")
                {
                    Move(0, -1, ref gameOver);
                }
                else if (command == "right")
                {
                    Move(0, 1, ref gameOver);
                }
                if (gameOver) break;

                command = Console.ReadLine();
            }
            PrintResult();
        }

        private static void FillTheMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        private static void PrintResult()
        {
            if (pollinatedFlowers < 5)
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            else
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            PrintTheMatrix();
        }
        private static void Move(int row, int col,ref bool gameOver)
        {
            matrix[playerRow, playerCol] = '.';
            playerRow += row;
            playerCol += col;
            if (IsIndexValid(playerRow, playerCol))
            {
                if (matrix[playerRow, playerCol] == 'f')
                {
                    pollinatedFlowers++;
                    matrix[playerRow, playerCol] = 'B';
                }
                else if (matrix[playerRow, playerCol] == 'O')
                    Move(row,col,ref gameOver);
                else
                    matrix[playerRow, playerCol] = 'B';
            }
            else
            {
                gameOver = true;
                playerRow += row;
                playerCol += col;
                Console.WriteLine($"The bee got lost!");
            }
        }
        private static void PrintTheMatrix()
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
