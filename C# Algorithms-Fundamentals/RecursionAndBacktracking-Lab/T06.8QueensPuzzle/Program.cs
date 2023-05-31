namespace T06._8QueensPuzzle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonal = new HashSet<int>();

        static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonal.Add(row - col);
                    attackedRightDiagonal.Add(row + col);
                    board[row, col] = true;

                    PutQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonal.Remove(row - col);
                    attackedRightDiagonal.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col)
            => !attackedRows.Contains(row) &&
               !attackedCols.Contains(col) &&
               !attackedLeftDiagonal.Contains(row - col) &&
               !attackedRightDiagonal.Contains(row + col);
    }
}