using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Armory
{
    internal class Program
    {
        static char[,] matrix;
        static int officerRow;
        static int officerCol;
        static List<int> mirrorCoordinates = new List<int>();
        static int bladesGoldCoins = 0;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                // char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (currRow[col] == 'M')
                    {
                        mirrorCoordinates.Add(row);
                        mirrorCoordinates.Add(col);
                    }
                    if (currRow[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    matrix[row, col] = currRow[col];
                }
            }

            string command = Console.ReadLine();
            while (bladesGoldCoins < 65)
            {
                matrix[officerRow, officerCol] = '-';
                if (command == "up")
                {
                    if (IsIndexValid(officerRow - 1, officerCol))
                    {
                        officerRow--;
                        Move();
                    }
                    else
                    {
                        Console.WriteLine($"I do not need more swords!");
                        break;
                    }

                }
                else if (command == "down")
                {
                    if (IsIndexValid(officerRow + 1, officerCol))
                    {
                        officerRow++;
                        Move();
                    }
                    else
                    {
                        Console.WriteLine($"I do not need more swords!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (IsIndexValid(officerRow, officerCol - 1))
                    {
                        officerCol--;
                        Move();
                    }
                    else
                    {
                        Console.WriteLine($"I do not need more swords!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (IsIndexValid(officerRow, officerCol + 1))
                    {
                        officerCol++;
                        Move();
                    }
                    else
                    {
                        Console.WriteLine($"I do not need more swords!");
                        break;
                    }
                }
                if (bladesGoldCoins >= 65) break;
                command = Console.ReadLine();
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            if (bladesGoldCoins >= 65)
                Console.WriteLine($"Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {bladesGoldCoins} gold coins.");
            PrintTheMatrix();
        }

        private static void Move()
        {
            if (char.IsDigit(matrix[officerRow, officerCol]))
            {
                bladesGoldCoins += int.Parse(matrix[officerRow, officerCol].ToString());
            }
            else if (matrix[officerRow, officerCol] == 'M')
            {
                matrix[mirrorCoordinates[0], mirrorCoordinates[1]] = '-';
                matrix[mirrorCoordinates[2], mirrorCoordinates[3]] = '-';
                int secondMirrorRow = mirrorCoordinates[0];
                int secondMirrorCol = mirrorCoordinates[1];
                if (mirrorCoordinates[0] == officerRow && mirrorCoordinates[1] == officerCol)
                {
                    secondMirrorRow = mirrorCoordinates[2];
                    secondMirrorCol = mirrorCoordinates[3];
                }
                officerRow = secondMirrorRow;
                officerCol = secondMirrorCol;
            }
            matrix[officerRow, officerCol] = 'A';
        }

        private static bool IsIndexValid(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
        private static void PrintTheMatrix()
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
