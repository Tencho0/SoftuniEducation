using System;
using System.Linq;

namespace T3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                        break;
                    }
                }
            }
            Console.WriteLine(sum);

            // int sum = 0;
            // for (int row = 0; row < matrix.GetLength(0); row++)
            // {
            //     for (int col = row; col < row + 1; col++)
            //     {
            //         sum += matrix[row, col];
            //     }
            // }
        }
    }
}
