using System;
using System.Collections.Generic;

namespace T02.Selling
{
    internal class Program
    {
        static int playerRow = -1;
        static int playerCol = -1;
        static int money = 0;
        static char[,] matrix;
        static List<int> pillars = new List<int>();
        static void Main(string[] args)
        {
            bool gameOver = false;
            int n = int.Parse(Console.ReadLine());
            FillTheMatrix(n);
            while (money < 50)
            {
                string command = Console.ReadLine();
                if (command == "up")
                    Move(-1, 0, ref gameOver);
                else if (command == "down")
                    Move(1, 0, ref gameOver);
                else if (command == "left")
                    Move(0, -1, ref gameOver);
                else if (command == "right")
                    Move(0, 1, ref gameOver);
                if (gameOver) break;
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            if (money >= 50)
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");

            PrintTheMatrix();
        }

        private static void Move(int row, int col, ref bool gameOver)
        {
            matrix[playerRow, playerCol] = '-';
            playerRow += row;
            playerCol += col;
            if (IsIndexValid(playerRow, playerCol))
            {
                if (char.IsDigit(matrix[playerRow, playerCol]))
                {
                    money += int.Parse(matrix[playerRow, playerCol].ToString());
                    matrix[playerRow, playerCol] = 'S';
                }
                else if (matrix[playerRow, playerCol] == 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    TeleportToNextPillar();
                }
            }
            else
            {
                playerRow -= row;
                playerCol -= col;
                Console.WriteLine($"Bad news, you are out of the bakery.");
                gameOver = true;
            }
        }

        private static void TeleportToNextPillar()
        {
            pillars.Remove(playerRow);
            pillars.Remove(playerCol);
            int pillarRow = pillars[0];
            int pillarCol = pillars[1];
            playerRow = pillarRow;
            playerCol = pillarCol;
            matrix[playerRow, playerCol] = 'S';
        }

        private static void FillTheMatrix(int n)
        {
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        pillars.Add(row);
                        pillars.Add(col);
                    }
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
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
