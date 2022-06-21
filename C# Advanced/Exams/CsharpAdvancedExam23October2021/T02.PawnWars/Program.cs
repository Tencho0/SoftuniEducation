using System;
using System.Linq;


//TODO: Rewrite the task

namespace T02.PawnWars
{
    internal class Program
    {
        static char[,] matrix = new char[8, 8];
        static int whitePawnRow = 0;
        static int whitePawnCol = 0;
        static int blackPawnRow = 0;
        static int blackPawnCol = 0;
        static void Main(string[] args)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                //char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }
                    else if (currRow[col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                    matrix[row, col] = currRow[col];
                }
            }

            while (true)
            {
                string coordinates = coordinates = $"{(char)('a' + 8-whitePawnRow + 1)}{8 - whitePawnCol}";
                if (IsIndexValid(whitePawnRow - 1, whitePawnCol + 1))
                {
                    if (matrix[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                    {
                        coordinates = $"{(char)('A' + 8-whitePawnRow)}{8 - whitePawnCol + 1}";
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                }
                if (IsIndexValid(whitePawnRow - 1, whitePawnCol - 1))
                {
                    if (matrix[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                    {
                        coordinates = $"{(char)('A' + 8-whitePawnRow)}{8 - whitePawnCol - 1}";
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        break;
                    }
                }
                if (IsIndexValid(whitePawnRow - 1, whitePawnCol))
                {
                    matrix[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow--;
                    matrix[whitePawnRow, whitePawnCol] = 'w';
                }
                else
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    break;
                }

                coordinates = $"{(char)('A' + 8- blackPawnRow)}{8 - blackPawnCol}";
                if (IsIndexValid(blackPawnRow + 1, blackPawnCol + 1))
                {
                    if (matrix[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                    {
                        coordinates = $"{(char)('A' + 8- blackPawnRow + 1)}{8 - blackPawnCol + 1}";
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                }
                if (IsIndexValid(blackPawnRow + 1, blackPawnCol - 1))
                {
                    if (matrix[blackPawnRow + 1, blackPawnCol - 1] == 'b')
                    {
                        coordinates = $"{(char)('A' + 8- blackPawnRow + 1)}{8 - blackPawnCol - 1}";
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        break;
                    }
                }
                if (IsIndexValid(blackPawnRow + 1, blackPawnCol))
                {
                    matrix[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow++;
                    matrix[blackPawnRow, blackPawnCol] = 'w';
                }
                else
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    break;
                }

            }
        }
        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
