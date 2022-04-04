using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.SetsofElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            int[] lengths = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = lengths[0];
            int m = lengths[1];
            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            List<int> nums = new List<int>();
            foreach (var item in firstSet)
            {
                //if (!secondSet.Contains(item))
                //{
                //    firstSet.Remove(item);
                //}
                if (secondSet.Contains(item))
                {
                    nums.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", nums));

           // firstSet.IntersectWith(secondSet);
            //foreach (var item in firstSet)
            //{
            //    Console.Write($"{item} ");
            //}
           //Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
