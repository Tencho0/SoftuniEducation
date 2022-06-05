using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> predicate = (x, n) => x % n != 0;
            List<int> numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivideavle = true;
                foreach (var divider in arr)
                {
                    if (predicate(i, divider))
                    {
                        isDivideavle = false;
                        break;
                    }
                }
                if (isDivideavle)
                    numbers.Add(i);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
