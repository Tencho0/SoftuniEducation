using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> teams = new Dictionary<string, SortedSet<string>>();
            string command = Console.ReadLine();
            while (command != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] givenCmd = command
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = givenCmd[0];
                    string forceUser = givenCmd[1];
                    if (!teams.ContainsKey(forceSide))
                    {
                        teams[forceSide] = new SortedSet<string>();
                    }

                    if (!teams[forceSide].Contains(forceUser))
                    {
                        teams[forceSide].Add(forceUser);
                    }
                }
                else if (command.Contains(" -> "))
                {
                    string[] givenCmd = command
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = givenCmd[0];
                    string forceSide = givenCmd[1];
                    if (!teams.ContainsKey(forceSide))
                    {
                        teams[forceSide] = new SortedSet<string>();
                    }

                    if (!teams[forceSide].Contains(forceUser))
                    {
                        foreach (var side in teams)
                        {
                            if (side.Value.Contains(forceUser))
                            {
                                side.Value.Remove(forceUser);
                                break;
                            }
                        }

                        teams[forceSide].Add(forceUser);

                    }
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                command = Console.ReadLine();
            }
            teams = teams
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            foreach (var side in teams)
            {
                if (side.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
