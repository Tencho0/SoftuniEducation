using System;

namespace P2
{
    internal class Program
    {
        static int vankoRow = -1;
        static int vankoCol = -1;
        static char[,] matrix;
        static int holes = 1;
        static int rods = 0;
        static bool isElectrocuted = false;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            FillTheMatrix(n);
            string command = Console.ReadLine();
            matrix[vankoRow, vankoCol] = '*';
            holes++;
            while (command != "End")
            {
                if (command == "up")
                    Move(-1, 0);
                else if (command == "down")
                    Move(1, 0);
                else if (command == "left")
                    Move(0, -1);
                else if (command == "right")
                    Move(0, 1);

                if (isElectrocuted) break;

                command = Console.ReadLine();
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            if (!isElectrocuted)
            {
                holes--;
                matrix[vankoRow, vankoCol] = 'V';
            }
            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }
            else if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }

            //   if(isElectrocuted)
            //   {
            //       Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            //   }
            //   else
            //   {
            //       Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            //   }

            PrintTheMatrix();
        }

        private static void Move(int row, int col)
        {
            //   if (index == 0)
            //       matrix[vankoRow, vankoCol] = '*';

            vankoRow += row;
            vankoCol += col;

            if (IsIndexValid(vankoRow, vankoCol))
            {
                if (IsThereAHole())
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }

                if (matrix[vankoRow, vankoCol] == 'R')
                {
                    rods++;
                    vankoRow -= row;
                    vankoCol -= col;
                    Console.WriteLine($"Vanko hit a rod!");
                }
                else if (matrix[vankoRow, vankoCol] == 'C')
                {
                    isElectrocuted = true;
                    matrix[vankoRow, vankoCol] = 'E';
                }
                else if (matrix[vankoRow, vankoCol] == '-')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    holes++;
                }
            }
            else
            {
                vankoRow -= row;
                vankoCol -= col;
            }
        }

        private static bool IsThereAHole()
        {
            return matrix[vankoRow, vankoCol] == '*' || matrix[vankoRow, vankoCol] == 'E';
        }
        private static void FillTheMatrix(int n)
        {
            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
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
