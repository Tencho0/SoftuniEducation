using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int givenNum = int.Parse(Console.ReadLine());
                if (!nums.ContainsKey(givenNum))
                {
                    nums[givenNum] = 0;
                }
                nums[givenNum]++;
            }

            nums = nums.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine(string.Join("\n", nums.Keys));
        }
    }
}
