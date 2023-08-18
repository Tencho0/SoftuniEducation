namespace Т03RoadTrip
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] spaces = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int maxCapacity = int.Parse(Console.ReadLine());

            int[,] dp = new int[values.Length + 1, maxCapacity + 1];

            for (int i = 0; i <= values.Length; i++)
            {
                for (int j = 0; j <= maxCapacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (spaces[i - 1] <= j)
                    {
                        dp[i, j] = Math.Max(values[i - 1] + dp[i - 1, j - spaces[i - 1]], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine($"Maximum value: {dp[values.Length, maxCapacity]}");
        }
    }
}