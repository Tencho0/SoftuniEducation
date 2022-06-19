using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BeaveratWork
{
    internal class Program
    {
        static char[,] matrix;
        static int beaverRow;
        static int beaverCol;
        static int woodBranch = 0;
        static List<char> woods = new List<char>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(currRow[col]))
                        woodBranch++;

                    matrix[row, col] = currRow[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                try
                {
                    if (command == "up")
                        Move(beaverRow - 1, beaverCol, "up");
                    else if (command == "down")
                        Move(beaverRow + 1, beaverCol, "down");
                    else if (command == "left")
                        Move(beaverRow, beaverCol - 1, "left");
                    else if (command == "right")
                        Move(beaverRow, beaverCol + 1, "right");
                }
                catch (ArgumentException e)
                {
                    break;
                }
                if (woodBranch == woods.Count) break;

                command = Console.ReadLine();
            }

            if (woods.Count == woodBranch)
            {
                Console.WriteLine($"The Beaver successfully collect {woods.Count} wood branches: {string.Join(", ", woods)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranch - woods.Count} branches left.");
            }
            PrintTheMatrix();
        }

        private static void Move(int row, int col, string command)
        {
            if (IsIndexValid(row, col))
            {
                matrix[beaverRow, beaverCol] = '-';
                beaverRow = row;
                beaverCol = col;

                if (char.IsLower(matrix[row, col]))
                    woods.Add(matrix[row, col]);
                else if (matrix[row, col] == 'F')
                {
                    if (command == "up")
                    {
                        if (row == 0)
                            Move(matrix.GetLength(0) - 1, col, "down");
                        else
                            Move(0, col, "up");
                    }
                    else if (command == "down")
                    {
                        if (row == matrix.GetLength(0) - 1)
                            Move(0, col, "down");
                        else
                            Move(matrix.GetLength(0), col, "up");
                    }
                    else if (command == "left")
                    {
                        if (col == 0)
                            Move(row, matrix.GetLength(1) - 1, "right");
                        else
                            Move(row, 0, "left");
                    }
                    else if (command == "right")
                    {
                        if (col == matrix.GetLength(1) - 1)
                            Move(row, 0, "left");
                        else
                            Move(row, matrix.GetLength(1), "right");
                    }

                }
                matrix[beaverRow, beaverCol] = 'B';
            }
            else
            {
                if (woods.Count > 0)
                {
                    woods.RemoveAt(woods.Count - 1);
                    woodBranch--;
                }
            }
            if (woodBranch == woods.Count)
            {
                throw new ArgumentException();
            }
        }

        private static bool IsIndexValid(int row, int col)
            => row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        private static void PrintTheMatrix()
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
