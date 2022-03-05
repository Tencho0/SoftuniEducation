using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!numbers.ContainsKey(arr[i]))
                {
                    numbers[arr[i]] = 0;
                }
                numbers[arr[i]]++;
            }
            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
