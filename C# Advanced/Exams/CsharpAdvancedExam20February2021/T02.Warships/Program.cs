using System;
using System.Linq;

namespace T02.Warships
{
    internal class Program
    {
        static int firstPlayerShips = 0;
        static int secondPlayerShips = 0;
        static char[,] matrix;
        static int totalCountShips;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] givenAttacks = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            FillTheMatrix(n);

            for (int i = 0; i < givenAttacks.Length; i++)
            {
                int[] currAttackArr = givenAttacks[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = currAttackArr[0];
                int col = currAttackArr[1];

                if (IsIndexValid(row, col))
                {
                    char element = matrix[row, col];

                    if (element == '#')
                        RemoveCellsAroundTheBomb(row, col);
                    else if (element == '<' || element == '>')
                    {
                        RemoveShip(element);
                        matrix[row, col] = 'X';
                    }
                }
                CheckIfPlayerWonABattle();
            }
            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        private static void RemoveCellsAroundTheBomb(int row, int col)
        {
            BombExplode(row - 1, col);
            BombExplode(row + 1, col);
            BombExplode(row, col - 1);
            BombExplode(row, col + 1);
            BombExplode(row + 1, col + 1);
            BombExplode(row - 1, col + 1);
            BombExplode(row - 1, col - 1);
            BombExplode(row + 1, col - 1);
        }

        private static void CheckIfPlayerWonABattle()
        {
            if (firstPlayerShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShips - (firstPlayerShips + secondPlayerShips)} ships have been sunk in the battle.");
                Environment.Exit(0);
            }
            else if (secondPlayerShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShips - (firstPlayerShips + secondPlayerShips)} ships have been sunk in the battle.");
                Environment.Exit(0);
            }
        }

        private static void FillTheMatrix(int n)
        {
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == '<')
                        firstPlayerShips++;
                    else if (currRow[col] == '>')
                        secondPlayerShips++;
                    matrix[row, col] = currRow[col];
                }
            }
            totalCountShips = firstPlayerShips + secondPlayerShips;
        }

        private static void BombExplode(int row, int col)
        {
            if (IsIndexValid(row, col))
            {
                char element = matrix[row, col];
                RemoveShip(element);
                matrix[row, col] = 'X';
            }
        }

        private static void RemoveShip(char element)
        {
            if (element == '>')
                secondPlayerShips--;
            else if (element == '<')
                firstPlayerShips--;
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] != 'X';
        }
    }
}
