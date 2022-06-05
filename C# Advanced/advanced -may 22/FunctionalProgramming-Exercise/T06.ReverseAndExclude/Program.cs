using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> predicate = x => x % n != 0;
            nums = nums.Where(x => predicate(x)).ToList();
            nums.Reverse();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
