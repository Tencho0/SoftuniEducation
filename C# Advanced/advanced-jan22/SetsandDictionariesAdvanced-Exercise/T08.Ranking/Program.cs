using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            while (command != "end of contests")
            {
                string[] givenCmd = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contestName = givenCmd[0];
                string password = givenCmd[1];
                contests[contestName] = password;
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "end of submissions")
            {
                string[] givenCmd = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = givenCmd[0];
                string password = givenCmd[1];
                string userName = givenCmd[2];
                int points = int.Parse(givenCmd[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!submissions.ContainsKey(userName))
                    {
                        submissions[userName] = new Dictionary<string, int>();
                    }
                    if (!submissions[userName].ContainsKey(contest))
                    {
                        submissions[userName][contest] = 0;
                    }
                    if (submissions[userName][contest] < points)
                    {
                        submissions[userName][contest] = points;
                    }
                }
                command = Console.ReadLine();
            }
            string bestUser = string.Empty;
            int bestPoints = int.MinValue;
            foreach (var currUser in submissions)
            {
                int currPoints = 0;
                currPoints += currUser.Value.Values.Sum();
                if (currPoints > bestPoints)
                {
                    bestPoints = currPoints;
                    bestUser = currUser.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var currUser in submissions)
            {
                var orderedUserContests = currUser.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x=>x.Key, y=> y.Value);
                
                Console.WriteLine(currUser.Key);
                foreach (var currContest in orderedUserContests)
                {
                    Console.WriteLine($"#  {currContest.Key} -> {currContest.Value}");
                }
            }
        }
    }
}
