using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> func = (x, y) => x % y == 0;
            int n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = true;
                foreach (var currDivider in dividers)
                {
                    if (!func(i, currDivider))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    nums.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
