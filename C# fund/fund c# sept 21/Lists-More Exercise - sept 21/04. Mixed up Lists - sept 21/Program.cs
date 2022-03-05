using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newList = new List<int>();
            List<int> finalList = new List<int>();
            int reps = Math.Min(firstList.Count, secondList.Count);
            for (int i = 0; i < reps; i++)
            {
                newList.Add(firstList[0]);
                newList.Add(secondList[secondList.Count - 1]);
                firstList.RemoveAt(0);
                secondList.RemoveAt(secondList.Count - 1);
            }

            if (firstList.Count > 0)
            {
                firstList.Sort();
                for (int i = 0; i < newList.Count; i++)
                {
                    if (firstList[0] < newList[i] && firstList[1] > newList[i])
                    {
                        finalList.Add(newList[i]);
                    }
                }
            }
            else
            {
                secondList.Sort();
                for (int i = 0; i < newList.Count; i++)
                {
                    if (secondList[0] < newList[i] && secondList[1] > newList[i])
                    {
                        finalList.Add(newList[i]);
                    }
                }
            }
            finalList.Sort();
            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
