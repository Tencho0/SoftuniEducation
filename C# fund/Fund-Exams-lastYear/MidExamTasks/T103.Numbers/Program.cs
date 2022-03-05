using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            double averageValue = list.Average();
            list.Sort();
            list.Reverse();
            List<int> newList = new List<int>();
            int count = 0;
            foreach (var item in list)
            {
                if (item > averageValue)
                {
                    newList.Add(item);
                }
                count++;
                if (count == 5) break;
            }
            if (newList.Count == 0 || list.Count == 1)
            {
                Console.WriteLine("No");
                return;
            }
            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
