using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstGivenBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondGivenBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> items = new List<int>();

            Queue<int> firstBox = new Queue<int>(firstGivenBox);
            Stack<int> secondBox = new Stack<int>(secondGivenBox);

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currFirst = firstBox.Peek();
                int currSecond = secondBox.Peek();
                int sum = currFirst + currSecond;

                if (sum % 2 == 0)
                {
                    items.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                    firstBox.Enqueue(secondBox.Pop());

            }
            if (firstBox.Count == 0)
                Console.WriteLine($"First lootbox is empty");
            if (secondBox.Count == 0)
                Console.WriteLine($"Second lootbox is empty");

            int totalSum = items.Sum();
            if (totalSum >= 100)
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            else
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
        }
    }
}
