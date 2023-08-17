namespace T01RodCutting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static int[] memo;
        private static int[] parent;

        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var lenght = int.Parse(Console.ReadLine());

            memo = new int[prices.Length];
            parent = new int[prices.Length];

            var bestPrice = CutRope(prices, lenght);

            Console.WriteLine(bestPrice);

            var parts = new List<int>();

            while (lenght != 0)
            {
                var current = parent[lenght];
                parts.Add(current);
                lenght -= current;
            }

            Console.WriteLine(string.Join(" ", parts));
        }

        private static int CutRope(int[] prices, int lenght)
        {
            if (lenght == 0)
            {
                return 0;
            }

            if (memo[lenght] > 0)
            {
                return memo[lenght];
            }

            var bestPrice = prices[lenght];
            var bestCombo = lenght;

            for (int i = 1; i < lenght; i++)
            {
                var currentPrice = prices[i] + CutRope(prices, lenght - i);

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            memo[lenght] = bestPrice;
            parent[lenght] = bestCombo;

            return bestPrice;
        }
    }
}