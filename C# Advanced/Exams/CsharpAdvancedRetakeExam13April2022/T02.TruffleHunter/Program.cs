using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TruffleHunter
{
    public class Program
    {
        static Dictionary<char, int> truffles = new Dictionary<char, int>()
        {
            {'B',0 },
            {'S',0 },
            {'W',0 }
        };
        static int wildBoarTruffles = 0;
        static char[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
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

                char element = matrix[row, col];

                if (action == "Collect")
                {
                    matrix[row, col] = '-';
                    if (truffles.ContainsKey(element))
                        truffles[element]++;
                }
                else if (action == "Wild_Boar")
                {
                    string direction = givenCmd[3];
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                            CollectElement(i, col);
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                            CollectElement(i, col);
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                            CollectElement(row, i);
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i += 2)
                            CollectElement(row, i);
                    }
                }
                command = Console.ReadLine();
            }
            PrintTheResult();
        }

        private static void PrintTheResult()
        {
            Console.WriteLine($"Peter manages to harvest {truffles['B']} black, {truffles['S']} summer, and {truffles['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffles} truffles.");
            PrintTheMatrix();
        }

        private static void CollectElement(int row, int col)
        {
            if (truffles.ContainsKey(matrix[row, col]))
                wildBoarTruffles++;
            matrix[row, col] = '-';
        }
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
