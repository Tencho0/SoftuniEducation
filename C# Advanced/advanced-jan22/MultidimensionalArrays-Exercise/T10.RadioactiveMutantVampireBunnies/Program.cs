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
    }
}



//if (IsIndicesValid(matrix, row - 1, col))
//{
//    if (matrix[row - 1, col] == 'P')
//    {
//        deathRow = row - 1;
//        deathCol = col;
//    }
//    matrix[row - 1, col] = 'B';
//}
//if (IsIndicesValid(matrix, row + 1, col))
//{
//    if (matrix[row + 1, col] == 'P')
//    {
//        deathRow = row + 1;
//        deathCol = col;
//    }
//    matrix[row + 1, col] = 'B';
//}
//if (IsIndicesValid(matrix, row, col - 1))
//{
//    if (matrix[row, col - 1] == 'P')
//    {
//        deathRow = row;
//        deathCol = col - 1;
//    }
//    matrix[row, col - 1] = 'B';
//}
//if (IsIndicesValid(matrix, row, col + 1))
//{
//    if (matrix[row, col + 1] == 'P')
//    {
//        deathRow = row;
//        deathCol = col + 1;
//    }
//    matrix[row, col + 1] = 'B';
//}



//    foreach (var currLetter in commands)
//    {
//        matrix[playerRow, playerCol] = '.';
//        if (currLetter == 'L')
//        {
//            playerCol--;
//        }
//        else if (currLetter == 'R')
//        {
//            playerCol++;
//        }
//        else if (currLetter == 'U')
//        {
//            playerRow--;
//        }
//        else if (currLetter == 'D')
//        {
//            playerRow++;
//        }
//        if (matrix[playerRow, playerCol] == 'B')
//        {
//            PrintLair(matrix);
//            Console.WriteLine($"dead: {playerRow} {playerCol}");
//        }
//        matrix[playerRow, playerCol] = 'P';
//        bool isChangedToBunny = false;
//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                if (matrix[row, col] == 'B')
//                {
//                    //OverCurrBunny
//                    if (IsBunnyIndexValid(matrix, row - 1, col))
//                    {
//                        CheckPlayerPossition(matrix, row - 1, col);
//                        matrix[row - 1, col] = 'B';
//                    }
//                    //UnderCurrBunny
//                    if (IsBunnyIndexValid(matrix, row + 1, col))
//                    {
//                        CheckPlayerPossition(matrix, row + 1, col);
//                        matrix[row + 1, col] = 'B';
//                    }
//                    //LeftFromCurrBunny
//                    if (IsBunnyIndexValid(matrix, row, col - 1))
//                    {
//                        CheckPlayerPossition(matrix, row, col -1 );
//                        matrix[row, col - 1] = 'B';
//                    }
//                    //RightToCurrBunny
//                    if (IsBunnyIndexValid(matrix, row, col + 1))
//                    {
//                        CheckPlayerPossition(matrix, row, col + 1);
//                        matrix[row, col + 1] = 'B';
//                    }
//                    isChangedToBunny = true;
//                    break;
//                }
//                if (isChangedToBunny)
//                {
//                    break;
//                }
//            }
//        }

//        if (IsPlayerOutOfLair(matrix, playerRow, playerCol))
//        {
//            PrintLair(matrix);
//        }
//    }
//}
//private static void CheckPlayerPossition(char[,] matrix, int row, int col)
//{
//    if (IsPlayerInCurrCell(matrix, row, col))
//    {
//        PrintLair(matrix);
//        Console.WriteLine($"dead: {row} {col}");
//        Environment.Exit(0);
//    }
//}

//private static bool IsPlayerInCurrCell(char[,] matrix, int row, int col)
//{
//    return matrix[row, col] == 'P';
//}

//private static bool IsBunnyIndexValid(char[,] matrix, int row, int col)
//{
//    return row >= 0
//        && col >= 0
//        && row < matrix.GetLength(0)
//        && col < matrix.GetLength(1);
//}

//private static void PrintLair(char[,] matrix)
//{
//    for (int row = 0; row < matrix.GetLength(0); row++)
//    {
//        for (int col = 0; col < matrix.GetLength(1); col++)
//        {
//            Console.Write($"{matrix[row, col]} ");
//        }
//        Console.WriteLine();
//    }
//}

//private static bool IsPlayerOutOfLair(char[,] matrix, int playerRow, int playerCol)
//{
//    return playerCol < 0
//        || playerRow < 0
//        || playerRow >= matrix.GetLength(0)
//        || playerCol >= matrix.GetLength(1);
//}