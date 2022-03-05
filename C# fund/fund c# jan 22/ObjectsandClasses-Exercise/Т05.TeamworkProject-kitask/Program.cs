using System;
using System.Collections.Generic;
using System.Linq;

namespace Т05.TeamworkProject_kitask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            RegisterTeams(teams, teamsCount);
            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArg = command.Split(("->"), StringSplitOptions.RemoveEmptyEntries);
                string memberName = joinArg[0];
                string teamName = joinArg[1];
                Team searchedTeam = teams.FirstOrDefault(team => team.Name == teamName);
                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                // using System LINQ:
                // if (teams.Any(team => team.Members.Contains(memberName)))
                //{
                //    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                //    continue;
                //}

                if (IsAlreadyMember(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(t => t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                searchedTeam.AddMember(memberName);

                List<Team> teamsWithMembers = teams
                    .Where(t => t.Members.Count > 0)
                    .OrderByDescending(t => t.Members.Count)
                    .ThenBy(t => t.Name)
                    .ToList();

                List<Team> teamsToDisband = teams
                    .Where(t => t.Members.Count == 0)
                    .OrderBy(t => t.Name)
                    .ToList();

                PrintValidTeams(teamsWithMembers);
                PrintInvalidTeams(teamsToDisband);
            }
        }
        static void PrintInvalidTeams(List<Team> teamsToDisband)
        {
            Console.WriteLine("Teams to disband:");
            foreach (var invalidTeam in teamsToDisband)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }
        static void PrintValidTeams(List<Team> teamsWithMembers)
        {
            foreach (var validTeam in teamsWithMembers)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");
                foreach (var currMember in validTeam.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {currMember}");
                }
            }
        }
        static bool IsAlreadyMember(List<Team> teams, string memberName)
        {
            foreach (var item in teams)
            {
                if (item.Members.Contains(memberName))
                {
                    return true;
                }
            }
            return false;
        }
        static void RegisterTeams(List<Team> teams, int teamsCount)
        {
            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamArg = Console.ReadLine().Split('-');
                string creatorName = teamArg[0];
                string teamName = teamArg[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team team = new Team(teamName, creatorName);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
        }
    }
    class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;
            this.Members = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public void AddMember(string member)
        {
            this.Members.Add(member);
        }
    }
}
