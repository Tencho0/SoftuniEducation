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
                try
                {
                    string[] givenCmd = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string currCommand = givenCmd[0];
                    string teamName = givenCmd[1];
                    if (currCommand == "Team")
                    {
                        Team team = new Team();
                        team.Name = teamName;
                        teams.Add(teamName, team);
                    }
                    else if (currCommand == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        string playerName = givenCmd[2];
                        int endurance = int.Parse(givenCmd[3]);
                        int sprint = int.Parse(givenCmd[4]);
                        int dribble = int.Parse(givenCmd[5]);
                        int passing = int.Parse(givenCmd[6]);
                        int shooting = int.Parse(givenCmd[7]);
                        Player player =
                            new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (currCommand == "Remove")
                    {
                        string playerName = givenCmd[2];
                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (currCommand == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
