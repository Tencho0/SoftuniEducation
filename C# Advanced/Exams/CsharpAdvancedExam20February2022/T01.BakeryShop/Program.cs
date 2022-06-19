using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BakeryShop
{
    internal class Program
    {
        static Dictionary<string, int> bakeryProducts = new Dictionary<string, int>()
        {
            {"Croissant", 0 },
            {"Muffin", 0 },
            {"Baguette", 0 },
            {"Bagel", 0 }
        };
        static void Main(string[] args)
        {
            double[] givenWater = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double[] givenFlour = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(double.Parse)
              .ToArray();

            Queue<double> water = new Queue<double>(givenWater);
            Stack<double> flour = new Stack<double>(givenFlour);

            while (water.Count > 0 && flour.Count > 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();
                double sum = currWater + currFlour;
                if (currWater == currFlour)
                    bakeryProducts["Croissant"]++;
                else if (sum * 0.6 == currFlour)
                    bakeryProducts["Muffin"]++;
                else if (sum * 0.7 == currFlour)
                    bakeryProducts["Baguette"]++;
                else if (sum * 0.8 == currFlour)
                    bakeryProducts["Bagel"]++;
                else
                {
                    double difference = Math.Abs(currWater - currFlour);
                    flour.Push(difference);
                    bakeryProducts["Croissant"]++;
                }
            }

            PrintResult(water, flour);
        }

        private static void PrintResult(Queue<double> water, Stack<double> flour)
        {
            foreach (var (productName, productCount) in bakeryProducts.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{productName}: {productCount}");

            if (water.Count == 0)
                Console.WriteLine($"Water left: None");
            else
                Console.WriteLine($"Water left: {string.Join(", ", water)}");

            if (flour.Count == 0)
                Console.WriteLine($"Flour left: None");
            else
                Console.WriteLine($"Flour left: { string.Join(", ", flour)}");
        }
    }
}
