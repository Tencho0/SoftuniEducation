using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>();
            Dictionary<string, int> jungMaterials = new Dictionary<string, int>();
            bool isLegendaryFound = false;

            legendaryItems["motes"] = 0;
            legendaryItems["shards"] = 0;
            legendaryItems["fragments"] = 0;

            while (!isLegendaryFound)
            {
                string[] commands = Console.ReadLine().Split();
                for (int i = 1; i < commands.Length; i += 2)
                {
                    string material = commands[i].ToLower();
                    if (material == "motes" || material == "shards" || material == "fragments")
                    {
                        legendaryItems[material] += int.Parse(commands[i - 1]);
                        if (legendaryItems[material] >= 250)
                        {
                            string legendaryItem = string.Empty;
                            if (material == "fragments")
                            {
                                legendaryItem = "Valanyr";
                            }
                            else if (material == "shards")
                            {
                                legendaryItem = "Shadowmourne";
                            }
                            else if (material == "motes")
                            {
                                legendaryItem = "Dragonwrath";
                            }
                            Console.WriteLine($"{legendaryItem} obtained!");
                            legendaryItems[material] -= 250;
                            isLegendaryFound = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!jungMaterials.ContainsKey(material))
                        {
                            jungMaterials[material] = 0;
                        }
                        jungMaterials[material] += int.Parse(commands[i - 1]);
                    }
                }
            }
            foreach (var item in legendaryItems.OrderByDescending(key => key.Key).ThenBy(value => value.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in jungMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
