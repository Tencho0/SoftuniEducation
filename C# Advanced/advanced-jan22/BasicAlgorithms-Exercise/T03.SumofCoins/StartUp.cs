namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int target = int.Parse(Console.ReadLine());
            var coins = ChooseCoins(nums, target);
            Console.WriteLine($"Number of coins to take: {coins.Values.Sum()}");
            foreach (var coin in coins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderBy(x => x).ToList();
            var result = new Dictionary<int, int>();

            int index = coins.Count - 1;
            while (index > -1)
            {
                int coin = coins[index];
                int coinCount = targetSum / coin;
                if (coinCount < 1)
                {
                    index--;
                    continue;
                }
                result.Add(coin, coinCount);
                targetSum -= coin * coinCount;
                if (targetSum ==0)
                {
                    break;
                }
            }
            if (targetSum > 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }
    }
}