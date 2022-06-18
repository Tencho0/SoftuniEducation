﻿using System;
using System.Linq;

namespace T07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunction = (x, y) =>
            (x % 2 == 0 && y % 2 != 0) ? -1 : (x % 2 != 0 && y % 2 == 0) ? 1 : x > y ? 1 : x < y ? -1 : 0;
            Array.Sort(arr, (x,y) => sortFunction(x, y));
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
