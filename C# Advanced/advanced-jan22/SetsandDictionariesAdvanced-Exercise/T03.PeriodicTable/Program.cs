using System;
using System.Collections.Generic;

namespace T03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in givenInput)
                {
                    if (!set.Contains(item))
                    {
                        set.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
