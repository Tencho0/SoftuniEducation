using System;
using System.Text.RegularExpressions;

namespace T02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([|#])(?<product>[A-Za-z\s]+)\1(?<date>[\d]{2}\/[\d]{2,}\/[\d]{2,})\1(?<calories>[\d]{1,5})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["product"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
