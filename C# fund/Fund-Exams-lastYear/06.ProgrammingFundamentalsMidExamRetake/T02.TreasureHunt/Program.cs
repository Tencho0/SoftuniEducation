using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split('|').ToList();
            string command = Console.ReadLine();
            while (command != "Yohoho!")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                if (currCommand == "Loot")
                {
                    InsertNewItem(loot, givenCommand);
                }
                else if (currCommand == "Drop")
                {
                    DropTheItem(loot, givenCommand);
                }
                else if (currCommand == "Steal")
                {
                    int count = int.Parse(givenCommand[1]);
                    if (IsCountBigger(count, loot))
                    {
                        Console.WriteLine(string.Join(", ", loot));
                        loot.Clear();
                    }
                    else
                    {
                        StealAFewItems(loot, count);
                    }
                }
                command = Console.ReadLine();
            }
            PrintTheResult(loot);
        }
        public static bool IsIndexValid(int index, List<string> loot)
        {
            if (index >= 0 && index < loot.Count)
            {
                return true;
            }
            return false;
        }
        public static bool IsCountBigger(int count, List<string> loot)
        {
            if (count >= loot.Count)
            {
                return true;
            }
            return false;
        }
        public static void PrintAverageGain(List<string> loot)
        {
            int sumOfLength = 0;
            foreach (var item in loot)
            {
                sumOfLength += item.Length;
            }
            double averageGain = sumOfLength * 1.0 / loot.Count;
            Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
        }
        public static void InsertNewItem(List<string> loot, string[] givenCommand)
        {
            List<string> newLoot = givenCommand.ToList();
            newLoot.RemoveAt(0);
            foreach (var item in newLoot)
            {
                if (!loot.Contains(item))
                {
                    loot.Insert(0, item);
                }
            }
        }
        public static void DropTheItem(List<string> loot, string[] givenCommand)
        {
            int index = int.Parse(givenCommand[1]);
            if (IsIndexValid(index, loot))
            {
                string temp = loot[index];
                loot.RemoveAt(index);
                loot.Add(temp);
            }
        }
        public static void StealAFewItems(List<string> loot, int count)
        {
            List<string> newList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                newList.Add(loot[loot.Count - 1]);
                loot.RemoveAt(loot.Count - 1);
            }
            newList.Reverse();
            Console.WriteLine(string.Join(", ", newList));
        }
        public static void PrintTheResult(List<string> loot)
        {
            if (loot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                PrintAverageGain(loot);
            }
        }
    }
}
