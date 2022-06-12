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
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            int woodCount = 0;
            List<char> woods = new List<char>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (char.IsLower(currRow[col]))
                        woodCount++;

                    if (currRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    matrix[row, col] = currRow[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up")
                {
                    if (IsIndexValid(beaverRow - 1, beaverCol))
                    {
                        char currElement = matrix[beaverRow - 1, beaverCol];
                        if (currElement == 'F')
                        {
                            matrix[beaverRow - 1, beaverCol] = '-';
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow - 1 == 0)
                            {
                                beaverRow = matrix.GetLength(0) - 1;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    woods.Add(matrix[beaverRow, beaverCol]);
                                    woodCount--;
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                                matrix[beaverRow - 1, beaverCol] = 'B';

                            if (woodCount == 0) break;
                            command = Console.ReadLine();
                            continue;
                        }
                        else if (char.IsLower(currElement))
                        {
                            woods.Add(currElement);
                            woodCount--;
                        }

                        matrix[beaverRow, beaverCol] = '-';
                        beaverRow--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (woods.Count > 0)
                            woods.RemoveAt(woods.Count - 1);
                    }
                }
                else if (command == "down")
                {
                    if (IsIndexValid(beaverRow + 1, beaverCol))
                    {
                        char currElement = matrix[beaverRow + 1, beaverCol];
                        if (currElement == 'F')
                        {
                            matrix[beaverRow + 1, beaverCol] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow + 1 == matrix.GetLength(0) - 1)
                            {
                                beaverRow = 0;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    woods.Add(matrix[beaverRow, beaverCol]);
                                    woodCount--;
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                                matrix[beaverRow + 1, beaverCol] = 'B';

                            if (woodCount == 0) break;
                            command = Console.ReadLine();
                            continue;
                        }
                        else if (char.IsLower(currElement))
                        {
                            woodCount--;
                            woods.Add(currElement);
                        }
                        matrix[beaverRow, beaverCol] = '-';
                        beaverRow++;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (woods.Count > 0)
                            woods.RemoveAt(woods.Count - 1);
                    }
                }
                else if (command == "left")
                {
                    if (IsIndexValid(beaverRow, beaverCol - 1))
                    {
                        char currElement = matrix[beaverRow, beaverCol - 1];
                        if (currElement == 'F')
                        {
                            matrix[beaverRow, beaverCol - 1] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverCol - 1 == 0)
                            {
                                beaverCol = matrix.GetLength(1) - 1;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    woods.Add(matrix[beaverRow, beaverCol]);
                                    woodCount--;
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                                matrix[beaverRow, beaverCol - 1] = 'B';

                            if (woodCount == 0) break;
                            command = Console.ReadLine();
                            continue;
                        }
                        else if (char.IsLower(currElement))
                        {
                            woodCount--;
                            woods.Add(currElement);
                        }
                        matrix[beaverRow, beaverCol] = '-';
                        beaverCol--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (woods.Count > 0)
                            woods.RemoveAt(woods.Count - 1);
                    }
                }
                else if (command == "right")
                {
                    if (IsIndexValid(beaverRow, beaverCol + 1))
                    {
                        char currElement = matrix[beaverRow, beaverCol + 1];
                        if (currElement == 'F')
                        {
                            matrix[beaverRow, beaverCol + 1] = 'B';
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverCol + 1 == matrix.GetLength(1) - 1)
                            {
                                beaverCol = 0;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    woods.Add(matrix[beaverRow, beaverCol]);
                                    woodCount--;
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                                matrix[beaverRow, beaverCol + 1] = 'B';

                            if (woodCount == 0) break;
                            command = Console.ReadLine();
                            continue;
                        }
                        else if (char.IsLower(currElement))
                        {
                            woodCount--;
                            woods.Add(currElement);
                        }

                        matrix[beaverRow, beaverCol] = '-';
                        beaverCol++;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (woods.Count > 0)
                            woods.RemoveAt(woods.Count - 1);
                    }
                }
                if (woodCount == 0) break;
                command = Console.ReadLine();
            }

            if (woodCount == 0)
                Console.WriteLine($"The Beaver successfully collect {woods.Count} wood branches: {string.Join(", ", woods)}.");
            else
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodCount} branches left.");
            PrintTheMatrix();
        }

        private static bool IsIndexValid(int row, int col)
            => row >= 0 && col >= 0 && matrix.GetLength(0) > row && matrix.GetLength(1) > col;
        private static void PrintTheMatrix()
        {
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                for (long col = 0; col < matrix.GetLength(1); col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.WriteLine();
            }
        }
    }
}
