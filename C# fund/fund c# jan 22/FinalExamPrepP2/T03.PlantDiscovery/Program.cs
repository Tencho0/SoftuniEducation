using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> plants = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split("<->");
                string name = givenCmd[0];
                int rarity = int.Parse(givenCmd[1]);
                if (!plants.ContainsKey(name))
                {
                    plants[name] = new List<int>();
                    plants[name].Add(rarity);
                }
                plants[name][0] = rarity;
            }
            string cmd = Console.ReadLine();
            while (cmd != "Exhibition")
            {
                string[] givenCmd = cmd.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string[] plantsInfo = givenCmd[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantsInfo[0];
                if (plants.ContainsKey(plantName))
                {
                    if (action == "Rate")
                    {
                        int rating = int.Parse(plantsInfo[1]);
                        plants[plantName].Add(rating);
                    }
                    else if (action == "Update")
                    {
                        int rarity = int.Parse(plantsInfo[1]);
                        plants[plantName][0] = rarity;
                    }
                    else if (action == "Reset")
                    {
                        int rarity = plants[plantName][0];
                        plants[plantName].Clear();
                        plants[plantName].Add(rarity);
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in plants)
            {
                int rarity = plant.Value[0];
                plant.Value.RemoveAt(0);
                double averageRating = 0;
                if (!(plant.Value.Count == 0))
                {
                    averageRating = plant.Value.Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {rarity}; Rating: {averageRating:F2}");
            }
        }
    }
}
