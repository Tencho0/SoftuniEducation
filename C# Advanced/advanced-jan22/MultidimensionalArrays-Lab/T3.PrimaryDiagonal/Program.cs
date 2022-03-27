using System;
using System.Linq;

namespace T3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col < row + 1; col++)
                {
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
