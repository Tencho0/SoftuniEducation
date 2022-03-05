using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();
            int biggerListCount = list.Count;
            if (biggerListCount < list2.Count)
            {
                biggerListCount = list2.Count;
            }
            for (int i = 0; i < biggerListCount; i++)
            {
                if (list.Count > i)
                {
                mergedList.Add(list[i]);
                }
                if (list2.Count > i)
                {
                mergedList.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}
