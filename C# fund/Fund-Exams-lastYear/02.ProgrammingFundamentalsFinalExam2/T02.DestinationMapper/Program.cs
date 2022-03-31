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
            string pattern = @"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> matchesList = new List<string>();
            int travelPoints = 0;
            foreach (Match currLocation in matches)
            {
                string currDestination = currLocation.Groups["destination"].Value;
                matchesList.Add(currDestination);
                travelPoints += currDestination.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", matchesList)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
