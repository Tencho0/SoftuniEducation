using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().TrimEnd();
            // string output = $"Player {Name}: {Class}" + Environment.NewLine;
            // output += $"Rank: {Rank}" + Environment.NewLine;
            // output += $"Description: {Description}";
            // return output.TrimEnd();
        }
        //private string name;
        //private string rank;
        //private string description;
        //public Player(string name, string clas)
        //{
        //    Name = name;
        //    Class = clas;
        //    Rank = "Trial";
        //    Description = "m/a";
        //}
        //public string Name
        //{
        //    get { return name; }
        //    private set { name = value; }
        //}
        //public string Class { get; private set; }
        //public string Rank
        //{
        //    get { return rank; }
        //    internal set { rank = value; }
        //}
        //public string Description
        //{
        //    get { return description; }
        //    set { description = value; }
        //}
        //public override string ToString()
        //{
        //    // string output = $"Player {Name}: {Class}" + Environment.NewLine;
        //    // output += $"Rank: {Rank}" + Environment.NewLine;
        //    // output += $"Description: {Description}";
        //    // return output.TrimEnd();

        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"Player {Name}: {Class}");
        //    sb.AppendLine($"Rank: {Rank}");
        //    sb.AppendLine($"Description: {Description}");

        //    return sb.ToString().TrimEnd();
        //}
    }
}
