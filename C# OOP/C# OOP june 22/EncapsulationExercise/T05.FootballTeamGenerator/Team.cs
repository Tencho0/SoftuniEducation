namespace T05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public int Rating =>
            players.Count > 0
            ? (int)Math.Round(players.Average(x => x.SkillLevel))
            : throw new ArgumentException($"{this.Name} - 0");
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"A name should not be empty.");
                }
                name = value;
            }
        }
        public IReadOnlyCollection<Player> Players => players;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(player);
        }
    }
}
