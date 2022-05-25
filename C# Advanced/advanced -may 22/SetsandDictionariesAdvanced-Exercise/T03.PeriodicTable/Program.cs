using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] givenElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in givenElements)
                    elements.Add(element);
            }
            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
