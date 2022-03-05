using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.SortedArrayDOT5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfElements = int.Parse(Console.ReadLine());
            List<int> array = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> first = new List<int>();
            List<int> second = new List<int>();
            List<int> sorted = new List<int>();
            for (int i = 0; i < countOfElements / 2; i++)
            {
                first.Add(array[0]);
                array.RemoveAt(0);
                second.Add(array[1]);
                array.RemoveAt(1);
            }
            if (array.Count == 1)
            {
                first.Add(array[0]);
            }
            first.Sort();
            second.Sort();
            if (first[0] > second[0])
            {
                for (int i = 0; i < countOfElements; i++)
                {
                    sorted.Add(first[0]);
                    sorted.Add(second[0]);
                    first.RemoveAt(0);
                    second.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < countOfElements / 2; i++)
                {
                    sorted.Add(second[0]);
                    sorted.Add(first[0]);
                    first.RemoveAt(0);
                    second.RemoveAt(0);
                }
            }
        Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
