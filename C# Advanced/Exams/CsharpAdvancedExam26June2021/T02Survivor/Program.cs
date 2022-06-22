using System;
using System.Collections.Generic;
using System.Linq;

namespace T02Survivor
{
    internal class Program
    {
        static char[][] beach;
        static List<char> collectedTokens = new List<char>();
        static List<char> opponentsTokens = new List<char>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            beach = new char[n][];
            for (int i = 0; i < n; i++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beach[i] = currRow;
            }

            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int row = int.Parse(givenCmd[1]);
                int col = int.Parse(givenCmd[2]);

                if (action == "Find")
                {
                    if (IsIndexValid(row, col))
                    {
                        collectedTokens.Add(beach[row][col]);
                        beach[row][col] = '-';
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = givenCmd[3];
                    if (IsIndexValid(row, col))
                    {
                        opponentsTokens.Add(beach[row][col]);
                        beach[row][col] = '-';
                        if (direction == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row--;
                                if (IsIndexValid(row, col))
                                {
                                    opponentsTokens.Add(beach[row][col]);
                                    beach[row][col] = '-';
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row++;
                                if (IsIndexValid(row, col))
                                {
                                    opponentsTokens.Add(beach[row][col]);
                                    beach[row][col] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                col--;
                                if (IsIndexValid(row, col))
                                {
                                    opponentsTokens.Add(beach[row][col]);
                                    beach[row][col] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                col++;
                                if (IsIndexValid(row, col))
                                {
                                    opponentsTokens.Add(beach[row][col]);
                                    beach[row][col] = '-';
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            PrintBeach();
            Console.WriteLine($"Collected tokens: {collectedTokens.Count}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens.Count}");
        }

        private static void PrintBeach()
        {
            for (int i = 0; i < beach.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < beach.GetLength(0) && col < beach[row].Length && beach[row][col] != '-';
        }
    }
}
