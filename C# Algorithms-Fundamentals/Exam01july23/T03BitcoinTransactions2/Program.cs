﻿namespace T03BitcoinTransactions2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ");
            string[] arr2 = Console.ReadLine().Split(" ");

            Stack<string> path = new Stack<string>();
            int[,] matrix = new int[arr1.Length + 1, arr2.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (arr1[row - 1] == arr2[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;

                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            int r = matrix.GetLength(0) - 1;
            int c = matrix.GetLength(1) - 1;
            int length = matrix[r, c];
            while (r > 0 && c > 0)
            {
                if (arr1[r - 1] == arr2[c - 1])
                {
                    path.Push(arr1[r - 1]);
                }

                if (matrix[r, c - 1] > matrix[r - 1, c])
                {
                    c--;
                }
                else
                {
                    r--;
                }
            }

            Console.Write("[");
            Console.Write(string.Join(" ", path));
            Console.Write("]");
        }
    }
}
