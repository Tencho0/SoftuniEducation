using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, string>> users = new Dictionary<string, Dictionary<string, string>>();

            while (command != "end of contests")
            {
                string[] givenCommand = command.Split(':');
                string contest = givenCommand[0];
                string password = givenCommand[1];
                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = password;
                }
                command = Console.ReadLine();
            }

            string submissions = Console.ReadLine();
            while (submissions != "end of submissions")
            {
                string[] givenCmd = submissions.Split("=>");
                string contest = givenCmd[0];
                string password = givenCmd[1];
                string username = givenCmd[2];
                int points = int.Parse(givenCmd[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        
                    }
                }
                submissions = Console.ReadLine();
            }
        }
    }
}
