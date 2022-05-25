using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.SetsofElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> elements = new HashSet<int>();
            HashSet<int> secondElements = new HashSet<int>();
         //   HashSet<int> duplicatedElements = new HashSet<int>();
            int[] countOfElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = countOfElements[0];
            int m = countOfElements[1];

            for (int i = 0; i < n; i++)
                elements.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < m; i++)
                secondElements.Add(int.Parse(Console.ReadLine()));

            List<int> duplicatedElements = new List<int>();
            foreach (var item in elements)
            {
                if (secondElements.Contains(item))
                    duplicatedElements.Add(item);
            }
            Console.WriteLine(string.Join(" ", duplicatedElements));

            //    for (int i = 0; i < m; i++)
            //    {
            //        int element = int.Parse(Console.ReadLine());
            //        if (elements.Contains(element))
            //            Console.Write(element + " ");
            //    }

            // for (int i = 0; i < m; i++)
            // {
            //     int currElement = int.Parse(Console.ReadLine());
            //     if (elements.Contains(currElement))
            //         duplicatedElements.Add(currElement);
            // }
            // Console.WriteLine(string.Join(" ", duplicatedElements));
        }
    }
}
