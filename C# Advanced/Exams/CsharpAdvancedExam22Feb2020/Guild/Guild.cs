using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private Dictionary<string, Player> roster;
        private string name;
        private int capacity;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new Dictionary<string, Player>();
        }

        public int Count => Roster.Count;
        public Dictionary<string, Player> Roster
        {
            get { return roster; }
            set { roster = value; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity && !Roster.ContainsKey(player.Name))
                Roster[player.Name] = player;
        }
        public bool RemovePlayer(string name)
        {
            if (Roster.ContainsKey(name))
            {
                Roster.Remove(name);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            if (Roster.ContainsKey(name))
            {
                if (Roster[name].Rank != "Member")
                {
                    Roster[name].Rank = "Member";
                }
            }
            // Roster[name].Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            if (Roster.ContainsKey(name))
            {
                if (Roster[name].Rank != "Trial")
                {
                    Roster[name].Rank = "Trial";
                }
            }
            // Roster[name].Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] playersToRemove = Roster.Values.Where(x => x.Class == @class).ToArray();

            // foreach (var item in playersToRemove)
            //     Roster.Remove(item.Name);
            roster = roster.Where(x => x.Value.Class != @class).ToDictionary(x => x.Key, x => x.Value);

            return playersToRemove;
        }
        public string Report()
        {
            string output = $"Players in the guild: {Name}";
            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    output += Environment.NewLine + player.Value.ToString();
                }
            }
            return output.ToString().TrimEnd();

            //  StringBuilder sb = new StringBuilder();
            //
            //  sb.AppendLine($"Players in the guild: {this.Name}");
            //
            //  foreach (var item in Roster)
            //      sb.AppendLine(item.Value.ToString());
            //
            //  return sb.ToString().TrimEnd();
        }
    }
}
