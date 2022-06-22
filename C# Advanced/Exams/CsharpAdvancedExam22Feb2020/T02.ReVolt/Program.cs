using System;
using System.Linq;

namespace T02.ReVolt
{
    internal class Program
    {
        static char[,] matrix;
        static int playerRow = -1;
        static int playerCol = -1;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int amountOfCommands = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = currRow[col];
                }
            }
            for (int i = 0; i < amountOfCommands; i++)
            {
                string comamnds = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                if (comamnds == "up")
                {
                    playerRow--;
                    if (IsIndexValid(playerRow, playerCol))
                    {
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                    }
                    if (playerRow < 0)
                        playerRow = matrix.GetLength(0) -1;
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine($"Player won!");
                        PrintTheMatrix();
                        return;
                    }
                }
                else if (comamnds == "down")
                {
                    playerRow++;
                    if (IsIndexValid(playerRow, playerCol))
                    {
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                    }
                    if (playerRow >= matrix.GetLength(0))
                        playerRow = 0;
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine($"Player won!");
                        PrintTheMatrix();
                        return;
                    }
                }
                else if (comamnds == "left")
                {
                    playerCol--;
                    if (IsIndexValid(playerRow, playerCol))
                    {
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                    }
                    if (playerCol < 0)
                        playerCol = matrix.GetLength(1) - 1;
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine($"Player won!");
                        PrintTheMatrix();
                        return;
                    }
                }
                else if (comamnds == "right")
                {

                    playerCol++;
                    if (IsIndexValid(playerRow, playerCol))
                    {
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                    }
                    if (playerCol >= matrix.GetLength(1))
                        playerCol = 0;
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        Console.WriteLine($"Player won!");
                        PrintTheMatrix();
                        return;
                    }
                }
            }
            matrix[playerRow, playerCol] = 'f';
            Console.WriteLine($"Player lost!");
            PrintTheMatrix();
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
