using System;
using System.Text.RegularExpressions;

namespace T03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Regex regex = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]+)\2(?<year>\d{4})\b");


            //Regex regex = new Regex(@"\b(\d{2})([-.\/])([A-Z][a-z]+)(\2)([\d]{4})");
            //string input = Console.ReadLine();
            //MatchCollection matches = regex.Matches(input);
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(?<day>[0-9]{2})(?<separators>[-.\/])(?<month>[A-Z][a-z]{2})(\k<separators>)(?<year>[0-9]{4})");
            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
