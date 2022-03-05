using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.SortedArray2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> sorted = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (list[i] >= list[j])
                    {
                        for (int k = j; k < n; k++)
                        {
                            if (list[j] <= list[k])
                            {
                                sorted.Add(list[i]);
                                sorted.Add(list[j]);
                                sorted.Add(list[k]);
                                list.Remove(list[i]);
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
