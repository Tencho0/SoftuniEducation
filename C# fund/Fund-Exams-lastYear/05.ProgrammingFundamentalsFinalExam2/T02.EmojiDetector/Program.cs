using System;
using System.Text.RegularExpressions;

namespace T02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long threshold = 1;
            string input = Console.ReadLine();
            string emojiPattern = @"([\:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            
            MatchCollection emojies = Regex.Matches(input, emojiPattern);
            MatchCollection digits = Regex.Matches(input, digitsPattern);
            foreach (Match digit in digits)
            {
                threshold *= long.Parse(digit.ToString());
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojies)
            {
                long coolness = 0;
                string currEmoji = emoji.Groups["emoji"].Value;
                foreach (char letter in currEmoji)
                {
                    coolness += letter;
                }
                if (coolness >= threshold)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
