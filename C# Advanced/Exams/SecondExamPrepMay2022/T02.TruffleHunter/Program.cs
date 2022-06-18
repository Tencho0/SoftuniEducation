using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static char[,] matrix;
        static Dictionary<char, int> petersTruffles = new Dictionary<char, int>()
            {
                {'B',0 },
                {'S',0 },
                {'W',0 },
                {'-', 0 }
            };
        static int wildBoardsTruffles = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];

                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);

                if (action == "Collect")
                {
                    if (IsIndexValid(row, col))
                    {
                        char currElement = matrix[row, col];
                        petersTruffles[currElement]++;
                        matrix[row, col] = '-';
                    }
                }
                else if (action == "Wild_Boar")
                {
                    string direction = givenCmd[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            CollectElement(i, col);
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                        {
                            CollectElement(i, col);
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i += 2)
                        {
                            CollectElement(row, i);
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            CollectElement(row, i);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Peter manages to harvest {petersTruffles['B']} black, {petersTruffles['S']} summer, and {petersTruffles['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoardsTruffles} truffles.");

            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void CollectElement(int row, int col)
        {
            char currElement = matrix[row, col];
            if (petersTruffles.ContainsKey(currElement) && currElement != '-')
                wildBoardsTruffles++;
            matrix[row, col] = '-';
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && matrix.GetLength(0) > row && matrix.GetLength(1) > col;
        }
    }
}
