using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.CountSameValuesinArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> nums = new Dictionary<double, int>();
            double[] givenInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            foreach (var currDigit in givenInput)
            {
                if (!nums.ContainsKey(currDigit))
                {
                    nums[currDigit] = 0;
                }
                nums[currDigit]++;
            }

            foreach (var currNum in nums)
            {
                Console.WriteLine($"{currNum.Key} - {currNum.Value} times");
            }
        }
    }
}
