using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T05.FootballTeamGenerator
{
    public class Team
    {
        private readonly Dictionary<string, Player> players;
        private string name;
        public Team()
        {
            players = new Dictionary<string, Player>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Rating => 
            players.Count > 0
            ? (int)Math.Round(players.Average(x => x.Value.SkillLevel))
            : throw new ArgumentException($"{this.Name} - 0");
        //{
        //    get
        //    {
        //        if (players.Count == 0)
        //        {
        //            throw new ArgumentException($"{this.Name} - 0");
        //        }
        //        return (int)Math.Round(players.Average(x => x.Value.SkillLevel));
        //    }
        //}

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }

        public void RemovePlayer(string player)
        {
            if (!players.ContainsKey(player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }
            players.Remove(player);
        }
    }
}
