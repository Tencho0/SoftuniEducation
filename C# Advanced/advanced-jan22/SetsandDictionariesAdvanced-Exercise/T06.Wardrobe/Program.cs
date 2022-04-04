using System;
using System.Collections.Generic;

namespace T06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenInput = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = givenInput[0];
                string[] givenItems = givenInput[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                foreach (var item in givenItems)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }
            }
            string[] givenCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string givenColor = givenCmd[0];
            string clothing = givenCmd[1];
            foreach (var currColor in wardrobe)
            {
                if (currColor.Key == givenColor)
                {
                    Console.WriteLine($"{givenColor} clothes:");
                    foreach (var item in currColor.Value)
                    {
                        if (item.Key == clothing)
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{currColor.Key} clothes:");
                    foreach (var item in currColor.Value)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
