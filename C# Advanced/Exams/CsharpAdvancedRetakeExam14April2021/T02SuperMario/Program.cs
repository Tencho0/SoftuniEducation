using System;
using System.Linq;

namespace T02SuperMario
{
    internal class Program
    {
        static char[][] matrix;
        static int playerRow = -1;
        static int playerCol = -1;
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currRow = Console.ReadLine();
                matrix[i] = currRow.ToCharArray();
                for (int j = 0; j < currRow.Length; j++)
                {
                    if (currRow[j] == 'M')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            bool gameOver = false;
            while (gameOver == false)
            {
                string command = Console.ReadLine();
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);

                matrix[row][col] = 'B';
                matrix[playerRow][playerCol] = '-';
                lives--;

                if (action == "W")
                {
                    if (IsIndexValid(playerRow - 1, playerCol))
                    {
                        playerRow--;
                        Move(ref lives, ref gameOver);
                    }
                }
                else if (action == "S")
                {
                    if (IsIndexValid(playerRow + 1, playerCol))
                    {
                        playerRow++;
                        Move(ref lives, ref gameOver);
                    }
                }
                else if (action == "A")
                {
                    if (IsIndexValid(playerRow, playerCol - 1))
                    {
                        playerCol--;
                        Move(ref lives, ref gameOver);
                    }
                }
                else if (action == "D")
                {
                    if (IsIndexValid(playerRow, playerCol + 1))
                    {
                        playerCol++;
                        Move(ref lives, ref gameOver);
                    }
                }
            }
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                Console.WriteLine(string.Join("", matrix[i]));
        }

        private static void Move(ref int lives, ref bool gameOver)
        {
            CheckIsBowser(ref lives);
            CheckIsAlive(lives, ref gameOver);
            CheckIsTherePrincess(ref lives, ref gameOver);
            if (gameOver == false)
                matrix[playerRow][playerCol] = 'M';
        }

        private static void CheckIsTherePrincess(ref int lives, ref bool gameOver)
        {
            if (matrix[playerRow][playerCol] == 'P')
            {
                matrix[playerRow][playerCol] = '-';
                gameOver = true;
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
        }

        private static void CheckIsBowser(ref int lives)
        {
            if (matrix[playerRow][playerCol] == 'B')
            {
                lives -= 2;
            }
        }

        private static void CheckIsAlive(int lives, ref bool gameOver)
        {
            if (lives <= 0 && matrix[playerRow][playerCol] != 'P')
            {
                gameOver = true;
                matrix[playerRow][playerCol] = 'X';
                Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
            }
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length;
        }

    }
}
