using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> finallist = new List<int>();
            int biggerCount = firstList.Count >= secondList.Count ? firstList.Count : secondList.Count;
            for (int i = 0; i < biggerCount; i++)
            {
                if (firstList.Count > i) finallist.Add(firstList[i]);
                if (secondList.Count > i) finallist.Add(secondList[i]);
            }
            Console.WriteLine(string.Join(" ", finallist));
        }
    }
}
