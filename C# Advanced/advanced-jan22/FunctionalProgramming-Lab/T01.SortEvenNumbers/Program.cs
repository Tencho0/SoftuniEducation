using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            nums = nums.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
