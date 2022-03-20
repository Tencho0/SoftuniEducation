using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int travelPoints = 0;
            string pattern = @"([=\/]{1})(?<destinations>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();

            foreach (Match match in matches)
            {
                string destination = match.Groups["destinations"].Value;
                destinations.Add(destination);
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
