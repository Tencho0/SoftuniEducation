using System;
using System.Linq;

namespace T02.TheBattleofTheFiveArmies
{
    internal class Program
    {
        //TODO: Format with jagged array
        static char[,] matrix;
        static int armyRow = 0;
        static int armyCol = 0;
        static void Main(string[] args)
        {
            double armyArmor = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
                return;

            matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    if (IsIndexValid(row, col))
                    {
                        if (currRow[col] == 'A')
                        {
                            armyRow = row;
                            armyCol = col;
                        }
                        matrix[row, col] = currRow[col];
                    }
                }
            }

            if (armyArmor <= 0 && matrix[armyRow, armyCol] != 'M')
            {
                matrix[armyRow, armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                PrintTheMatrix();
                return;
            }

            string command;
            while (true)
            {
                command = Console.ReadLine();
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int orcRow = int.Parse(givenCmd[1]);
                int orcCol = int.Parse(givenCmd[2]);

                matrix[orcRow, orcCol] = 'O';

                armyArmor--;
                if (action == "up")
                {
                    if (IsIndexValid(armyRow - 1, armyCol))
                    {
                        matrix[armyRow, armyCol] = '-';
                        armyRow--;
                    }
                    else continue;
                }
                else if (action == "down")
                {
                    if (IsIndexValid(armyRow + 1, armyCol))
                    {
                        matrix[armyRow, armyCol] = '-';
                        armyRow++;
                    }
                    else continue;
                }
                else if (action == "left")
                {
                    if (IsIndexValid(armyRow, armyCol - 1))
                    {
                        matrix[armyRow, armyCol] = '-';
                        armyCol--;
                    }
                    else continue;
                }
                else if (action == "right")
                {
                    if (IsIndexValid(armyRow, armyCol + 1))
                    {
                        matrix[armyRow, armyCol] = '-';
                        armyCol++;
                    }
                    else continue;
                }

                if (matrix[armyRow, armyCol] == 'O')
                    armyArmor -= 2;

                else if (matrix[armyRow, armyCol] == 'M')
                {
                    matrix[armyRow, armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    break;
                }

                if (armyArmor <= 0 && matrix[armyRow, armyCol] != 'M')
                {
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    matrix[armyRow, armyCol] = 'X';
                    break;
                }
                matrix[armyRow, armyCol] = 'A';
            }
            PrintTheMatrix();
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
