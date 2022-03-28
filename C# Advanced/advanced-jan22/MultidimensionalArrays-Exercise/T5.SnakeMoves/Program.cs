using System;
using System.Linq;

namespace T5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            char[,] matrix = new char[inputData[0], inputData[1]];
            bool rightToLeft = true;
            int indexOfSymbol =0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (rightToLeft)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[indexOfSymbol++];
                        if (indexOfSymbol == snake.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }

                    rightToLeft = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[indexOfSymbol++];
                        if (indexOfSymbol == snake.Length)
                        {
                            indexOfSymbol = 0;
                        }
                    }
                    rightToLeft = true;
                }
            }
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
