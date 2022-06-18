using System;
using System.Linq;

namespace T02.Warships
{
    internal class Program
    {
        public static char[,] matrix;
        static int firstPlayerShips = 0;
        static int secondPlayerShips = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] givenCmd = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (currRow[col] == '<')
                        firstPlayerShips++;
                    else if (currRow[col] == '>')
                        secondPlayerShips++;
                }
            }

            int totalCountShips = firstPlayerShips + secondPlayerShips;

            for (int i = 0; i < givenCmd.Length; i++)
            {
                int[] coordinates = givenCmd[i]
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                (int row, int col) = (coordinates[0], coordinates[1]);

                if (IsIndexValid(row, col))
                {
                    char item = matrix[row, col];
                    if (item == '#') ExplodesMine(row, col);
                    ReduceTheCell(row, col);

                    if (firstPlayerShips <= 0)
                    {
                        Console.WriteLine($"Player Two has won the game! {totalCountShips - (firstPlayerShips + secondPlayerShips)} ships have been sunk in the battle.");
                        return;
                    }
                    else if (secondPlayerShips <= 0)
                    {
                        Console.WriteLine($"Player One has won the game! {totalCountShips - (firstPlayerShips + secondPlayerShips)} ships have been sunk in the battle.");
                        return;
                    }
                }
            }
            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        private static void ExplodesMine(int row, int col)
        {
            if (IsIndexValid(row - 1, col)) ReduceTheCell(row - 1, col);
            if (IsIndexValid(row - 1, col + 1)) ReduceTheCell(row - 1, col + 1);
            if (IsIndexValid(row - 1, col - 1)) ReduceTheCell(row - 1, col - 1);
            if (IsIndexValid(row, col - 1)) ReduceTheCell(row, col - 1);
            if (IsIndexValid(row, col + 1)) ReduceTheCell(row, col + 1);
            if (IsIndexValid(row + 1, col + 1)) ReduceTheCell(row + 1, col + 1);
            if (IsIndexValid(row + 1, col)) ReduceTheCell(row + 1, col);
            if (IsIndexValid(row + 1, col - 1)) ReduceTheCell(row + 1, col - 1);
        }

        static void ReduceTheCell(int row, int col)
        {
            if (matrix[row, col] == '<')
                firstPlayerShips--;
            else if (matrix[row, col] == '>')
                secondPlayerShips--;

            matrix[row, col] = 'X';
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] != 'X';
        }
    }
}
