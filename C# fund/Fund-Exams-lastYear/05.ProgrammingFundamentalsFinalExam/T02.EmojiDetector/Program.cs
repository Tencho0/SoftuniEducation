using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long threshold = 1;
            string input = Console.ReadLine();
            string emojiesPattern = @"([\:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"[0-9]";
            MatchCollection emojiesMatches = Regex.Matches(input, emojiesPattern);
            MatchCollection digitsMatches = Regex.Matches(input, digitsPattern);
            foreach (Match currDigit in digitsMatches)
            {
                threshold *= long.Parse(currDigit.Value);
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojiesMatches.Count} emojis found in the text. The cool ones are:");
            foreach (Match currEmoji in emojiesMatches)
            {
                long coolness = 0;
                string emoji = currEmoji.Groups["emoji"].Value;
                foreach (char letter in emoji)
                {
                    coolness += letter;
                }
                if (coolness >= threshold)
                {
                    Console.WriteLine(currEmoji);
                }
            }
        }
    }
}
