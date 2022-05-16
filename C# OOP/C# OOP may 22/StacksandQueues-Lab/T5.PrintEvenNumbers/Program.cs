using System;
using System.Collections.Generic;
using System.Linq;

namespace T5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(arr);
            List<int> evenValues = new List<int>();
            foreach (var item in queue)
            {
                if (item % 2 == 0)
                {
                    evenValues.Add(item);
                }
            }
            Console.WriteLine(string.Join(", ", evenValues));
        }
    }
}
