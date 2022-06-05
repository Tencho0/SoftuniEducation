using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FindEvensorOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string cmd = Console.ReadLine();
            Predicate<int> predicate = x => x % 2 == 0;
            if (cmd == "odd")
            {
                predicate = x => x % 2 != 0;
            }
            List<int> nums = new List<int>();
            for (int i = ranges[0]; i <= ranges[1]; i++)
            {
                if (predicate(i))
                    nums.Add(i);
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
