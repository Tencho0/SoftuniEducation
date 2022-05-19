using System;
using System.Linq;

namespace T1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            int[,] matrix = new int[size,size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] givenRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                firstDiagonalSum += givenRow[row];
                secondDiagonalSum += givenRow[givenRow.Length - 1 - row];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = givenRow[col];
                }
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum -secondDiagonalSum));
        }
    }
}
