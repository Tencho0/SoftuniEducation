using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();
            int travelPoints = 0;
            foreach (Match match in matches)
            {
                string destination = match.Groups["destination"].Value;
                destinations.Add(destination);
                travelPoints += destination.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
