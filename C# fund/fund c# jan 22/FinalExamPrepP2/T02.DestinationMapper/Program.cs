using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> strigns = new List<string>();
            int travelPoints = 0;
            foreach (Match match in matches)
            {
                strigns.Add(match.Groups["destination"].Value);
                travelPoints += match.Groups["destination"].Value.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", strigns)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
