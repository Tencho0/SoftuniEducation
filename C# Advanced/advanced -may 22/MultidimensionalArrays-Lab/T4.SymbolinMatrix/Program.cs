using System;
using System.Linq;

namespace T4.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // char[] currRow = Console.ReadLine()
                //     .Split("", StringSplitOptions.RemoveEmptyEntries)
                //     .Select(char.Parse)
                //     .ToArray();
                string currRow = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char item = matrix[i, j];
                    if (item == symbolToFind)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbolToFind} does not occur in the matrix");
        }
    }
}
