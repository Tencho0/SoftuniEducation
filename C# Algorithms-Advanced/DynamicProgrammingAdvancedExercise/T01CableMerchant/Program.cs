namespace T01CableMerchant
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int> prices;
        private static int[] memo;

        static void Main(string[] args)
        {
            prices = new List<int>() { 0 };

            prices.AddRange(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            var connectorPrice = int.Parse(Console.ReadLine());

            memo = new int[prices.Count];

            CutRob(prices.Count - 1, connectorPrice);

            Console.WriteLine(string.Join(' ', memo.Skip(1)));
        }

        private static int CutRob(int length, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (memo[length] != 0)
            {
                return memo[length];
            }

            var currentBestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i] + CutRob(length - i, connectorPrice) - 2 * connectorPrice;

                if (currentPrice > currentBestPrice)
                {
                    currentBestPrice = currentPrice;
                }
            }

            memo[length] = currentBestPrice;

            return currentBestPrice;
        }
    }
}