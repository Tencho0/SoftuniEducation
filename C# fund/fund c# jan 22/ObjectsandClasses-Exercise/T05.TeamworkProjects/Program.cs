using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.TeamworkProjects
{
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] info = Console.ReadLine().Split("-");
                var creator = info[0];
                var teamName = info[1];
                if (teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    var team = new Team();
                    team.Name = teamName;
                    team.Creator = creator;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
            var line = Console.ReadLine();
            while (line != "end of assignment")
            {
                var user = line.Split(new string[] { "->" }, StringSplitOptions.None)[0];
                var teamToJoin = line.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                if (!teams.Any(team => team.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teams.Any(team => team.Members.Contains(user) || teams.Any(team => team.Creator == user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                }
                else
                {
                    var currTeam = teams.First(team => team.Name == teamToJoin);
                    currTeam.Members.Add(user);
                }
                line = Console.ReadLine();
            }
            var finalTeams = teams.Where(team => team.Members.Count > 0);
            var disbandedTeams = teams.Where(team => team.Members.Count == 0);
            foreach (Team team in finalTeams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name))
            {
                Console.WriteLine($"{team.Name}"); 
                Console.WriteLine($"- {team.Creator}");
                foreach (string member in team.Members.OrderBy(member => member))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            if (disbandedTeams != null)
            {
                foreach (var disbandedTeam in disbandedTeams.OrderBy(team => team.Name))
                {
                    Console.WriteLine($"{disbandedTeam.Name}");
                }
            }
        }
    }
}
