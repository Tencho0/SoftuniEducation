namespace T02BattlePoints
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var energy = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var battlePoits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var heroEnergy = int.Parse(Console.ReadLine());

            var dp = new int[energy.Length + 1, heroEnergy + 1];

            for (int enemyIdx = 1; enemyIdx < dp.GetLength(0); enemyIdx++)
            {
                var currnetEnergy = energy[enemyIdx - 1];
                var currentBattlePoits = battlePoits[enemyIdx - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[enemyIdx - 1, capacity];

                    if (capacity < currnetEnergy)
                    {
                        dp[enemyIdx, capacity] = excluding;
                        continue;
                    }

                    var including = currentBattlePoits + dp[enemyIdx - 1, capacity - currnetEnergy];

                    dp[enemyIdx, capacity] = Math.Max(including, excluding);
                }
            }

            Console.WriteLine(dp[energy.Length, heroEnergy]);
        }
    }
}