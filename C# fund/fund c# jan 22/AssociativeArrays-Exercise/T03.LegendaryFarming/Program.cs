using System;
using System.Collections.Generic;

namespace T03.LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            Dictionary<string, int> junkItems = new Dictionary<string, int>();
            bool isFound = false;
            items["shards"] = 0;
            items["motes"] = 0;
            items["fragments"] = 0;

            while (!isFound)
            {
                string[] commands = Console.ReadLine().Split();
                for (int i = 1; i < commands.Length; i+= 2)
                {
                    string item = commands[i].ToLower();
                    int count = int.Parse(commands[i - 1]);
                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        items[item] += count;
                        if (items[item] >= 250)
                        {
                            items[item] -= 250;
                            isFound = true;
                            if (item == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (item == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(item))
                        {
                            junkItems[item] = 0;
                        }
                        junkItems[item] += count;
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
