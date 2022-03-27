using System;

namespace JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[3][];
            for (int row = 0; row < rows; row++)
            {
                int columns = int.Parse(Console.ReadLine());
                jaggedArray[row] = new int[columns];
                for (int col = 0; col < columns; col++)
                {
                    jaggedArray[row][col] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
