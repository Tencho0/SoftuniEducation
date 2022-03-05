using System;
using System.Collections.Generic;
using System.Linq;

namespace T102.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            while (command != "Yohoho!")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                if (currCommand == "Loot")
                {
                    InsertTheItems(givenCommand, chest);
                }
                else if (currCommand == "Drop")
                {
                    DropTheItems(givenCommand, chest);
                }
                else if (currCommand == "Steal")
                {
                    StealTheItems(givenCommand, chest);
                }
                command = Console.ReadLine();
            }
            PrintTheResult(chest);
        }
        public static void InsertTheItems(string[] givenCommand, List<string> chest)
        {
            List<string> items = givenCommand.ToList();
            items.RemoveAt(0);
            foreach (var item in items)
            {
                if (!chest.Contains(item))
                {
                    chest.Insert(0, item);
                }
            }
        }
        public static void DropTheItems(string[] givenCommand, List<string> chest)
        {
            int index = int.Parse(givenCommand[1]);
            if (IsIndexValid(index, chest))
            {
                string temp = chest[index];
                chest.RemoveAt(index);
                chest.Add(temp);
            }
        }

        private static void StealTheItems(string[] givenCommand, List<string> chest)
        {
            int count = int.Parse(givenCommand[1]);
            if (IsCountBigger(count, chest))
            {
                Console.WriteLine(string.Join(", ", chest));
                chest.Clear();
            }
            else
            {
                List<string> stolenItems = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    stolenItems.Add(chest[chest.Count - 1]);
                    chest.RemoveAt(chest.Count - 1);
                }
                stolenItems.Reverse();
                Console.WriteLine(string.Join(", ", stolenItems));
            }
        }

        private static void PrintTheResult(List<string> chest)
        {
            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                int sumOfItemsLengths = 0;
                foreach (var item in chest)
                {
                    sumOfItemsLengths += item.Length;
                }
                double averageGain = sumOfItemsLengths * 1.0 / chest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }

        public static bool IsIndexValid(int index, List<string> chest)
        {
            return index >= 0 && index < chest.Count();
        }
        public static bool IsCountBigger(int count, List<string> chest)
        {
            return count >= chest.Count;
        }
    }
}
