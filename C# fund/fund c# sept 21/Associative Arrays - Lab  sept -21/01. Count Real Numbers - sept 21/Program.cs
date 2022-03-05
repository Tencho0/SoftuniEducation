using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            SortedDictionary<double, int> doubleCurrences = new SortedDictionary<double, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!doubleCurrences.ContainsKey(numbers[i]))
                {
                    doubleCurrences.Add(numbers[i], 0);
                }
                doubleCurrences[numbers[i]]++;
            }
            foreach (var item in doubleCurrences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
