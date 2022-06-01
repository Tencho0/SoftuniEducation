using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> findMin = x=>x.Min();
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Console.WriteLine(findMin(nums));
        }
    }
}
