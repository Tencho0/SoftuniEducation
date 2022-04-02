using System;
using System.Text.RegularExpressions;

namespace T02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([|#])(?<product>[A-Za-z\s]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>[\d]{1,5})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                int calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;
            }
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match item in matches)
            {
                string name = item.Groups["product"].Value;
                string date = item.Groups["date"].Value;
                int calories = int.Parse(item.Groups["calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
