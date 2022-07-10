using System;
using System.Collections.Generic;

namespace T05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string teamName = givenCmd[1];

                try
                {
                    if (action == "Team")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Team team = new Team(teamName);
                            teams[teamName] = team;
                        }
                    }
                    else if (action == "Add")
                    {
                        if (teams.ContainsKey(teamName))
                        {
                            string playerName = givenCmd[2];
                            int endurance = int.Parse(givenCmd[3]);
                            int sprint = int.Parse(givenCmd[4]);
                            int dribble = int.Parse(givenCmd[5]);
                            int passing = int.Parse(givenCmd[6]);
                            int shooting = int.Parse(givenCmd[7]);

                            Player playerToAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayer(playerToAdd);
                        }
                        else Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else if (action == "Remove")
                    {
                        string playerToRemove = givenCmd[2];
                        teams[teamName].RemovePlayer(playerToRemove);
                    }
                    else if (action == "Rating")
                    {
                        if (teams.ContainsKey(teamName))
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                        else
                            Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
