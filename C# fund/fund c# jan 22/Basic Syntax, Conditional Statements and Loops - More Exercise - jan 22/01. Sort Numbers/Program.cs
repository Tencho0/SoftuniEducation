using System;
using System.Collections.Generic;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];
            nums[0] = int.Parse(Console.ReadLine());
            nums[1] = int.Parse(Console.ReadLine());
            nums[2] = int.Parse(Console.ReadLine());
            Array.Sort(nums);
            for (int i = 3 - 1; i >= 0; i--)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
