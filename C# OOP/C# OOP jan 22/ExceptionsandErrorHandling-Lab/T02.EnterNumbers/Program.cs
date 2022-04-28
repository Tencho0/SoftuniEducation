using System;
using System.Collections.Generic;

namespace T02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            int n = 1;
            while (nums.Count != 10)
            {
                try
                {
                    ReadNumber(1, 100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Your number is not in range {n} - 100!");
                }
                n++;
            }
        }

        public static void ReadNumber(int start, int end)
        {

        }
    }
}
