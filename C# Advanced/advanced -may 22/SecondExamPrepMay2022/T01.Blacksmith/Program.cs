using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Blacksmith
{
    internal class Program
    {
        static Dictionary<int, string> swords = new Dictionary<int, string>()
        {
            {70, "Gladius"},
            {80, "Shamshir" },
            {90, "Katana"},
            {110, "Sabre"},
            {150, "Broadsword"}
        };
        static Dictionary<string, int> collectedSwords = new Dictionary<string, int>()
            {
                 {"Gladius", 0},
                 {"Shamshir" , 0},
                 {"Katana", 0},
                 {"Sabre", 0},
                 {"Broadsword", 0}
            };
        static void Main(string[] args)
        {
            int[] givenSteals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] givenCarbons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steals = new Queue<int>(givenSteals);
            Stack<int> carbons = new Stack<int>(givenCarbons);

            while (steals.Count > 0 && carbons.Count > 0)
            {
                int steel = steals.Dequeue();
                int carbon = carbons.Peek();

                int sum = steel + carbon;

                if (swords.ContainsKey(sum))
                {
                    carbons.Pop();
                    string sword = swords[sum];
                    collectedSwords[sword]++;
                }
                else
                    carbons.Push(carbons.Pop() + 5);
            }

            PrintResult(steals, carbons);
        }

        private static void PrintResult(Queue<int> steals, Stack<int> carbons)
        {
            var collectedSwordsSorted = collectedSwords.Where(x => x.Value > 0).OrderBy(x => x.Key);

            if (collectedSwordsSorted.Count() > 0)
                Console.WriteLine($"You have forged {collectedSwordsSorted.Sum(x=> x.Value)} swords.");
            else
                Console.WriteLine($"You did not have enough resources to forge a sword.");

            if (steals.Count == 0)
                Console.WriteLine("Steel left: none");
            else
                Console.WriteLine($"Steel left: {string.Join(", ", steals)}");

            if (carbons.Count == 0)
                Console.WriteLine("Carbon left: none");
            else
                Console.WriteLine($"Carbon left: {string.Join(", ", carbons)}");

            foreach (var (currSword, amount) in collectedSwordsSorted)
                Console.WriteLine($"{currSword}: {amount}");
        }
    }
}
