using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(" ", Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Where(x => x % int.Parse(Console.ReadLine()) != 0)
            //    .Reverse()));
            //return;

            Func<int, int, bool> divisible = (x, y) => x % y != 0;

            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());
            nums = nums.Where(x => divisible(x, n)).ToList();
            nums.Reverse();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
