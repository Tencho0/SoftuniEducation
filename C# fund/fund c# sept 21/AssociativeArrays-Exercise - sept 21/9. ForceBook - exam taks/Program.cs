using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook___exam_taks
{
    class Program
    {
        static void Main(string[] args)
        {
            // lecture "Associative Arrays" - 1:50:00

            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    var data = input.Split(" | ");
                    string side = data[0];
                    string user = data[1];
                    if (!forceSides.ContainsKey(side))
                    {
                        forceSides.Add(side, new List<string>());
                    }
                    if (!forceSides[side].Contains(user) && !forceSides.Values.Any(users => users.Contains(user)))
                    {
                        forceSides[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    var data = input.Split(" -> ");
                    string user = data[0];
                    string side = data[1];
                    if (!forceSides.Values.Any(users => users.Contains(user)))
                    {
                        if (!forceSides.ContainsKey(side))
                        {
                            forceSides.Add(side, new List<string>());
                        }
                        forceSides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var sides in forceSides.Where(side => side.Value.Contains(user)))
                        {
                            sides.Value.Remove(user);
                        }

                        if (!forceSides.ContainsKey(side))
                        {
                            forceSides.Add(side, new List<string>());
                        }
                        forceSides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
                input = Console.ReadLine();
            }
            forceSides = forceSides.OrderByDescending(key => key.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, u => u.Value);
            foreach (var side in forceSides)
            {
                side.Value.Sort();
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    Console.Write("! ");
                    Console.WriteLine(string.Join("\n! ", side.Value));
                }

            }
        }
    }
}
