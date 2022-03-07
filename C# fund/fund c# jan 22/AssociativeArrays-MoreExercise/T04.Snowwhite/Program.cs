using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Dictionary<string, Dictionary<string, int>>> dwarfs = new List<Dictionary<string, Dictionary<string, int>>>();
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            while (command != "Once upon a time")
            {
                string[] givenCmd = command.Split(" <:> ");
                string dwarfName = givenCmd[0];
                string dwarfHatColor = givenCmd[1];
                int dwarftPhisics = int.Parse(givenCmd[2]);
                if (!dwarfs.ContainsKey(dwarfHatColor))
                {
                    dwarfs[dwarfHatColor] = new Dictionary<string, int>();
                    dwarfs[dwarfHatColor][dwarfName] = dwarftPhisics;
                }
                else if (dwarfs.ContainsKey(dwarfHatColor) && (!dwarfs[dwarfHatColor].ContainsKey(dwarfName)))
                {
                    dwarfs[dwarfHatColor][dwarfName] = dwarftPhisics;
                }
                else
                {
                    if (dwarfs[dwarfHatColor][dwarfName] < dwarftPhisics)
                    {
                        dwarfs[dwarfHatColor][dwarfName] = dwarftPhisics;
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                foreach (var item in dwarf.Value.OrderByDescending(x => x.Value))
                {
                    Console.Write($"({dwarf.Key}) ");
                    Console.WriteLine($"{item.Key} <-> {item.Value}");
                }
            }
        }
    }
}
