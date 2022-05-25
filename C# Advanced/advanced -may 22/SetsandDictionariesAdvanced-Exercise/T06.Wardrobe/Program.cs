using System;
using System.Collections.Generic;

namespace T06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothers = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = givenCmd[0];
                string[] givenClothers = givenCmd[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!clothers.ContainsKey(color))
                    clothers[color] = new Dictionary<string, int>();

                foreach (var item in givenClothers)
                {
                    if (!clothers[color].ContainsKey(item))
                        clothers[color][item] = 0;

                    clothers[color][item]++;
                }
            }
            string[] findItemArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string findColor = findItemArr[0];
            string findItem = findItemArr[1];

            foreach (var (color, currClothes) in clothers)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (item, count) in currClothes)
                {
                    if (color == findColor && item == findItem)
                        Console.WriteLine($"* {item} - {count} (found!)");
                    else
                        Console.WriteLine($"* {item} - {count}");
                }
            }
        }
    }
}
