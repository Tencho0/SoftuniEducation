using System;
using System.Linq;

namespace T7.KnightGame
{
    internal class Program
    {
        static char[,] board;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            board = new char[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string lane = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = lane[col];
                }
            }

            int removeCount = 0;
            while (true)
            {
                int maxAttack = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(0); col++)
                    {
                        if (IsInRange(row, col) && board[row, col] == '0')
                            continue;

                        int currCount = 0;
                        if (IsInRange(row - 2, col - 1) && IsKnight(row - 2, col - 1))
                            currCount++;
                        if (IsInRange(row - 2, col + 1) && IsKnight(row - 2, col + 1))
                            currCount++;
                        if (IsInRange(row - 1, col - 2) && IsKnight(row - 1, col - 2))
                            currCount++;
                        if (IsInRange(row + 1, col - 2) && IsKnight(row + 1, col - 2))
                            currCount++;
                        if (IsInRange(row + 2, col - 1) && IsKnight(row + 2, col - 1))
                            currCount++;
                        if (IsInRange(row + 2, col + 1) && IsKnight(row + 2, col + 1))
                            currCount++;
                        if (IsInRange(row - 1, col + 2) && IsKnight(row - 1, col + 2))
                            currCount++;
                        if (IsInRange(row + 1, col + 2) && IsKnight(row + 1, col + 2))
                            currCount++;

                        if (currCount > maxAttack)
                        {
                            maxAttack = currCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxAttack > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removeCount++;
                }
                else break;
            }
            Console.WriteLine(removeCount);
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
        public static bool IsKnight(int row, int col)
        {
            return board[row, col] == 'K';
        }
    }
}
