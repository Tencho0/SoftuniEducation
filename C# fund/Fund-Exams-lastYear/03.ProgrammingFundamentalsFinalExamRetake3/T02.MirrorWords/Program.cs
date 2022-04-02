using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            if (matches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            List<string> mirrors = new List<string>();
            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;
                string reversed = string.Join("", secondWord.Reverse());
                if (firstWord == reversed)
                {
                    mirrors.Add($"{firstWord} <=> {secondWord}");
                }
            }
            if (mirrors.Count == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine($"{string.Join(", ", mirrors)}");
            }
        }
    }
}
