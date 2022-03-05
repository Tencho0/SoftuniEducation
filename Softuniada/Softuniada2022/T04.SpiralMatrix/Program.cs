using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.SpiralMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int columms = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < lines; i++)
            {
                int[] givenLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i == 0)
                {
                    result.AddRange(givenLine);
                }
                else
                {
                    result.Add(givenLine[givenLine.Length - 1]);
                    for (int j = 0; j < givenLine.Length - 1; j++)
                    {
                        nums.Add(givenLine[j]);
                    }
                }
            }
            int reps = columms - 1;

            for (int i = 0; i < reps; i++)
            {
                result.Add(nums[nums.Count - 1]);
                nums.RemoveAt(nums.Count - 1);
            }
            if (lines == 4)
            {
                int index = nums.Count - (columms - 1);
                result.Add(nums[index]);
                nums.RemoveAt(index);
                int repss = nums.Count();
                for (int i = 0; i < repss; i++)
                {
                    result.Add(nums[0]);
                    nums.RemoveAt(0);
                }
            }
            else if (lines == 3)
            {
                int repsToReverse = nums.Count;
                for (int i = 0; i < repsToReverse; i++)
                {
                    result.Add(nums[0]);
                    nums.RemoveAt(0);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
