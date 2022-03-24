using System;
using System.Collections.Generic;
using System.Linq;

namespace T5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //Queue<int> queue = new Queue<int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] % 2 == 0)
            //    {
            //        queue.Enqueue(nums[i]);
            //    }
            //}
            //Console.WriteLine(string.Join(", ", queue))

            List<int> finalNums = new List<int>();
            Queue<int> queue = new Queue<int>(nums);
            while (queue.Count > 0)
            {
                int num = queue.Peek();
                if (num % 2 == 0)
                {
                    finalNums.Add(num);
                }
                queue.Dequeue();
            }
            Console.WriteLine(string.Join(", ", finalNums));
        }
    }
}
