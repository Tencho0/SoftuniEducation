using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.SortedArray3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            Console.WriteLine(String.Join(" ", list));


            Console.WriteLine();
        }
    }
}
