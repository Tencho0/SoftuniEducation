using System;
using System.Linq;

namespace T1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];
            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            int sum = 0;
            int secSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
                secSum += matrix[i, matrix.GetLength(1) - 1 - i];
            }
            Console.WriteLine(Math.Abs(sum - secSum));
        }
    }
}
