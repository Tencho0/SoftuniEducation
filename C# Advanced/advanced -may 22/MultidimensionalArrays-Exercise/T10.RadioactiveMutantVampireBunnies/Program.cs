using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] givenSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = givenSize[0];
            int m = givenSize[1];

            char[,] matrix = new char[n, m];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool hasWon = false;
            bool isDead = false;

            string commands = Console.ReadLine();

            foreach (var currLetter in commands)
            {
                int nextRow = 0;
                int nextCol = 0;

                if (currLetter == 'L')
                {
                    nextCol = -1;
                }
                else if (currLetter == 'R')
                {
                    nextCol = 1;
                }
                else if (currLetter == 'U')
                {
                    nextRow = -1;
                }
                else if (currLetter == 'D')
                {
                    nextRow = 1;
                }

                matrix[playerRow, playerCol] = '.';

                if (!IsIndicesValid(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    hasWon = true;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    isDead = true;
                }
                else if (!hasWon)
                {
                    matrix[playerRow, playerCol] = 'P';
                }

                List<int[]> bunnies = ReturnBunniesIndices(matrix);

                foreach (var bunny in bunnies)
                {
                    int bunnyRow = bunny[0];
                    int bunnyCol = bunny[1];

                    //Up
                    CheckForPossition(matrix, bunnyRow - 1, bunnyCol, ref isDead);
                    //Down
                    CheckForPossition(matrix, bunnyRow + 1, bunnyCol, ref isDead);
                    //Left
                    CheckForPossition(matrix, bunnyRow, bunnyCol - 1, ref isDead);
                    //Right
                    CheckForPossition(matrix, bunnyRow, bunnyCol + 1, ref isDead);
                }

                if (hasWon)
                {
                    PrintTheMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
                if (isDead)
                {
                    PrintTheMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }

        }
        private static List<int[]> ReturnBunniesIndices(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }
            return bunnies;
        }
        private static void CheckForPossition(char[,] matrix, int bunnyRow, int bunnyCol, ref bool isDead)
        {
            if (IsIndicesValid(matrix, bunnyRow, bunnyCol))
            {
                if (matrix[bunnyRow, bunnyCol] == 'P')
                {
                    isDead = true;
                }
                matrix[bunnyRow, bunnyCol] = 'B';
            }
        }
        private static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0
                && col >= 0
                && row < matrix.GetLength(0)
                && col < matrix.GetLength(1);
        }
        private static void PrintTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        //static char[,] matrix;
        //static int playerRow;
        //static int playerCol;
        //static string state;
        //static bool isDead;
        //static void Main(string[] args)
        //{
        //    int[] size = Console.ReadLine()
        //          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //          .Select(int.Parse)
        //          .ToArray();
        //    matrix = new char[size[0], size[1]];
        //    FillTheMatrix();

        //    string commands = Console.ReadLine();

        //    foreach (var currCmd in commands)
        //    {
        //        MovePlayer(currCmd);
        //        if (HasPlayerWon()) state = "won";
        //        else
        //        {
        //            if (matrix[playerRow, playerCol] == 'B')
        //            {
        //                state = "dead";
        //                isDead = true;
        //            }
        //            else if (matrix[playerRow, playerCol] == '.')
        //            {
        //                matrix[playerRow, playerCol] = 'P';
        //            }
        //        }

        //        // MoveBunnies
        //        for (int row = 0; row < matrix.GetLength(0); row++)
        //        {
        //            for (int col = 0; col < matrix.GetLength(1); col++)
        //            {
        //                if (matrix[row, col] == 'B')
        //                {
        //                    MoveBunny(row - 1, col);
        //                    MoveBunny(row - 1, col + 1);
        //                    MoveBunny(row - 1, col - 1);
        //                    MoveBunny(row, col - 1);
        //                    MoveBunny(row, col + 1);
        //                    MoveBunny(row - 1, col + 1);
        //                    MoveBunny(row - 1, col - 1);
        //                    MoveBunny(row - 1, col);
        //                }
        //                if (isDead) break;
        //            }
        //            if (isDead) break;
        //        }
        //        if (isDead) break;
        //        if (state == "won") break;
        //    }
        //    PrintTheMatrix();
        //    if (state == "won")
        //    {
        //        if (playerRow < 0)
        //        {
        //            playerRow = 0;
        //        }
        //        if (playerCol < 0)
        //        {
        //            playerCol = 0;
        //        }
        //        if (playerRow >= matrix.GetLength(0))
        //        {
        //            playerRow = matrix.GetLength(0) - 1;
        //        }
        //        if (playerCol >= matrix.GetLength(1))
        //        {
        //            playerCol = matrix.GetLength(1) - 1;
        //        }
        //    }
        //    Console.WriteLine($"{state}: {playerRow} {playerCol}");
        //}
        //private static void MoveBunny(int row, int col)
        //{
        //    if (IsIndexValid(row, col))
        //    {
        //        if (IsTherePerson(row, col))
        //        {
        //            state = "dead";
        //            isDead = true;
        //        }
        //        matrix[row, col] = 'B';
        //    }
        //}
        //private static bool IsTherePerson(int row, int col)
        //{
        //    return matrix[row, col] == 'P';
        //}
        //private static void PrintTheMatrix()
        //{
        //    for (long row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (long col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write($"{matrix[row, col]} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //private static void MovePlayer(char currCmd)
        //{
        //    matrix[playerRow, playerCol] = '.';
        //    if (currCmd == 'L') playerCol--;
        //    if (currCmd == 'R') playerCol++;
        //    if (currCmd == 'U') playerRow--;
        //    if (currCmd == 'D') playerRow++;
        //}
        //private static void FillTheMatrix()
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        string currRow = Console.ReadLine();
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            matrix[row, col] = currRow[col];
        //            if (currRow[col] == 'P')
        //            {
        //                playerRow = row;
        //                playerCol = col;
        //            }
        //        }
        //    }
        //}
        //private static bool HasPlayerWon()
        //{
        //    return playerRow < 0 || playerRow >= matrix.GetLength(0) || playerCol < 0 || playerCol >= matrix.GetLength(1);
        //}
        //private static bool IsIndexValid(int row, int col)
        //{
        //    return row >= 0
        //        && col >= 0
        //        && row < matrix.GetLength(0)
        //        && col < matrix.GetLength(1)
        //        && matrix[row, col] != 'B';
        //}
    }
}
