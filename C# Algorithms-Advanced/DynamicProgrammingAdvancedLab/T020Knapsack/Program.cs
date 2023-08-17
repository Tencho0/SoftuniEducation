namespace T020Knapsack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        class Item
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public int Value { get; set; }
        }

        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var items = new List<Item>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var itemInput = input
                    .Split();

                var item = new Item()
                {
                    Name = itemInput[0],
                    Weight = int.Parse(itemInput[1]),
                    Value = int.Parse(itemInput[2])
                };

                items.Add(item);
            }

            var dp = new int[items.Count + 1, maxCapacity + 1];
            var used = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var itemsIndex = row - 1;
                var item = items[itemsIndex];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];

                    if (item.Weight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    var including = item.Value + dp[row - 1, capacity - item.Weight];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        used[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }

                }
            }

            var currentCapacity = maxCapacity;
            var itemStack = new SortedSet<string>();
            var totalWeight = 0;

            for (int row = used.GetLength(0) - 1; row > 0; row--)
            {
                if (used[row, currentCapacity])
                {
                    var item = items[row - 1];
                    currentCapacity -= item.Weight;

                    totalWeight += item.Weight;
                    itemStack.Add(item.Name);
                }

                if (currentCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {dp[items.Count, maxCapacity]}");
            foreach (var item in itemStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}