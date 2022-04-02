using System;
using System.Text.RegularExpressions;

namespace T02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string digitsPattern = @"[\d]";
            string pattern = @"([\:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string input = Console.ReadLine();
            long threshold = 1;
            MatchCollection digits = Regex.Matches(input, digitsPattern);
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match digit in digits)
            {
                threshold *= int.Parse(digit.Value);
            }
            if (digits.Count == 0)
            {
                threshold = 0;
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match match in matches)
            {
                long coolnes = 0;
                foreach (char letter in match.Groups["emoji"].Value)
                {
                    coolnes += letter;
                }
                if (coolnes >= threshold)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
