using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "exam finished")
            {
                string[] givenCmd = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = givenCmd[0];
                string language = givenCmd[1];
                if (language == "banned")
                {
                    users.Remove(username);
                }
                else
                {
                    int points = int.Parse(givenCmd[2]);
                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }
                    submissions[language]++;

                    if (!users.ContainsKey(username))
                    {
                        users[username] = 0;
                    }
                    if (users[username] < points)
                    {
                        users[username] = points;
                    }
                }

                command = Console.ReadLine();
            }
            users = users
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key, y=> y.Value);

            Console.WriteLine("Results:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            submissions = submissions
              .OrderByDescending(x => x.Value)
              .ThenBy(x => x.Key)
              .ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"Submissions:");
            foreach (var currLanguage in submissions)
            {
                Console.WriteLine($"{currLanguage.Key} - {currLanguage.Value}");
            }
        }
    }
}
