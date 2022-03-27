using System;

namespace T4.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] arr = new char[rows, rows];
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rows; col++)
                {
                    arr[row, col] = input[col];
                }
            }
            char givenChar = char.Parse(Console.ReadLine());
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == givenChar)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{givenChar} does not occur in the matrix");
        }
    }
}
