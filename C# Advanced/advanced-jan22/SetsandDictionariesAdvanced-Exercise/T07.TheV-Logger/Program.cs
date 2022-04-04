using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vloggersNames = new HashSet<string>();
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string action = command[1];
                if (action == "joined")
                {
                    if (!vloggersNames.Contains(name))
                    {
                        vloggers[name] = new Vlogger();
                        vloggersNames.Add(name);
                    }
                }
                if (action == "followed")
                {
                    FollowVlogger(vloggers, vloggersNames, command, name);
                }
                input = Console.ReadLine();
            }

            PrintOrderedVloggers(vloggers);
        }

        private static void FollowVlogger(Dictionary<string, Vlogger> vloggers, HashSet<string> vloggersNames, string[] command, string name)
        {
            string secondVlogger = command[2];
            if (name != secondVlogger
                && vloggersNames.Contains(name)
                && vloggersNames.Contains(secondVlogger)
                && !vloggers[name].Following.Contains(secondVlogger))
            {
                vloggers[name].Following.Add(secondVlogger);
                vloggers[secondVlogger].Followers.Add(name);
            }
        }

        private static void PrintOrderedVloggers(Dictionary<string, Vlogger> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = OrderVloggers(vloggers);
            PrintTheFamoustOne(vloggers);
            PrintAnotherVloggers(vloggers);
        }

        private static Dictionary<string, Vlogger> OrderVloggers(Dictionary<string, Vlogger> vloggers)
        {
            vloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count).ToDictionary(x => x.Key, y => y.Value);
            return vloggers;
        }

        private static void PrintTheFamoustOne(Dictionary<string, Vlogger> vloggers)
        {
            KeyValuePair<string, Vlogger> mostFamousVlogger = vloggers.First();
            vloggers.Remove(mostFamousVlogger.Key);

            Console.WriteLine($"1. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Following.Count} following");

            foreach (var follower in mostFamousVlogger.Value.Followers)
            {
                Console.WriteLine($"*  {follower}");
            }
        }

        private static void PrintAnotherVloggers(Dictionary<string, Vlogger> vloggers)
        {
            int currVloggerPossition = 2;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{currVloggerPossition++}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }
        }
    }
    class Vlogger
    {
        public Vlogger()
        {
            Followers = new SortedSet<string>();
            Following = new SortedSet<string>();
        }
        public SortedSet<string> Followers { get; set; }
        public SortedSet<string> Following { get; set; }
    }
}
