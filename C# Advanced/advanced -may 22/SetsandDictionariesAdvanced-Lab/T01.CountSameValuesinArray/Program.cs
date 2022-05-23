using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.CountSameValuesinArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            foreach (var item in arr)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 0;
                }
                dictionary[item]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
