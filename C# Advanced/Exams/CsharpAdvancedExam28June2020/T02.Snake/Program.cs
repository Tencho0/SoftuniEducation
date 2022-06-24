using System;
using System.Collections.Generic;

namespace T02.Snake
{
    internal class Program
    {
        static char[,] matrix;
        static int snakeRow = -1;
        static int snakeCol = -1;
        static int foodQuantity = 0;
        static List<int> burrwosCoordinates = new List<int>();
        static bool gameOver = false;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            FillTheMatrix(n);
            while (gameOver == false)
            {
                string command = Console.ReadLine();
                if (command == "up")
                    Move(-1, 0);
                else if (command == "down")
                    Move(1, 0);
                else if (command == "left")
                    Move(0, -1);
                else if (command == "right")
                    Move(0, 1);

                if (foodQuantity >= 10) break;
                // gameOver = true;
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            if (gameOver)
                Console.WriteLine($"Game over!");
            else
                Console.WriteLine($"You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintTheMatrix();
        }

        private static void Move(int row, int col)
        {
            matrix[snakeRow, snakeCol] = '.';
            snakeRow += row;
            snakeCol += col;
            if (IsIndexValid(snakeRow, snakeCol))
            {
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                    TeleportSnake();
            }
            else
            {
                gameOver = true;
                snakeRow -= row;
                snakeCol -= col;
            }
        }
        private static void TeleportSnake()
        {
            matrix[snakeRow, snakeCol] = '.';
            int newBurrowRow = burrwosCoordinates[0];
            int newBurrowCol = burrwosCoordinates[1];
            if (burrwosCoordinates[0] == snakeRow && burrwosCoordinates[1] == snakeCol)
            {
                newBurrowRow = burrwosCoordinates[2];
                newBurrowCol = burrwosCoordinates[3];
            }
            snakeRow = newBurrowRow;
            snakeCol = newBurrowCol;
            matrix[snakeRow, snakeCol] = 'S';
        }
        private static void FillTheMatrix(int n)
        {
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (currRow[col] == 'B')
                    {
                        burrwosCoordinates.Add(row);
                        burrwosCoordinates.Add(col);
                    }
                    matrix[row, col] = currRow[col];
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
