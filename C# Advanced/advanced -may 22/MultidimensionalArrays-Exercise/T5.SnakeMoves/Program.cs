using System;
using System.Linq;

namespace T5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            string command = Console.ReadLine();

            int index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = command[index];
                        index++;
                        if (index >= command.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = command[index];
                        index++;
                        if (index >= command.Length)
                        {
                            index = 0;
                        }
                    }
                }
            }
            PrintTheMaxtrix(matrix);
        }
        private static void PrintTheMaxtrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
