using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = x => x.Select(y => y += 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(y => y *= 1).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(y => y -= 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                    nums = add(nums);
                else if (command == "subtract")
                    nums = subtract(nums);
                else if (command == "multiply")
                    nums = multiply(nums);
                else if (command == "print")
                    print(nums);

                command = Console.ReadLine();
            }
        }
    }
}
