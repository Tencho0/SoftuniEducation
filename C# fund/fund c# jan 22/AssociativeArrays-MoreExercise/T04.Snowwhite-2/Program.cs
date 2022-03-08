using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();
            var hatColors = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ");
                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);
                string currentDwarf = $"{dwarfName} {dwarfHatColor}";
                if (!dwarfs.ContainsKey(currentDwarf))
                {
                    dwarfs.Add(currentDwarf, dwarfPhysics);
                    if (!hatColors.ContainsKey(dwarfHatColor))
                    {
                        hatColors.Add(dwarfHatColor, 1);
                    }
                    else
                    {
                        hatColors[dwarfHatColor]++;
                    }
                }
                else if (dwarfs[currentDwarf] < dwarfPhysics)
                {
                    dwarfs[currentDwarf] = dwarfPhysics;
                }

            }
            var hatColorsOrdered = hatColors.OrderByDescending(x => x.Value);
            List<string> hatColorsWithIndexes = new List<string>();

            foreach (var hatColor in hatColorsOrdered)
            {
                hatColorsWithIndexes.Add(hatColor.Key);
            }

            var dwarfsUpdated = new Dictionary<string[], int>();
            foreach (var dwarf in dwarfs)
            {
                dwarfsUpdated.Add(dwarf.Key.Split(), dwarf.Value);
            }

            var orderedDwarfs = dwarfsUpdated.OrderByDescending(x => x.Value)
                                      .ThenBy(x => hatColorsWithIndexes.IndexOf(x.Key[1]));
            foreach (var dwarf in orderedDwarfs)
            {
                Console.WriteLine($"({dwarf.Key[1]}) {dwarf.Key[0]} <-> {dwarf.Value}");
            }

        }
    }
}
