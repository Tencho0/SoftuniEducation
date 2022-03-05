using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> finalList = new List<int>();
            sequence.Sort();
            sequence.Reverse();
            int sumOfElements = sequence.Sum();
            double averageNum = sumOfElements / (sequence.Count * 1.0);
            foreach (var item in sequence)
            {
                if (item > averageNum)
                {
                    finalList.Add(item);
                }
            }
            if (sequence.Count == 1 || finalList.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            finalList.Sort();
            finalList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                if (finalList.Count > i)
                {
                    Console.Write(finalList[i] + " ");
                }
            }
        }
    }
}
