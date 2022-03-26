using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary<string, string> mirrors = new Dictionary<string, string>();
            //List<string> mirrors = new List<string>();

            string text = Console.ReadLine();
            string pattern = @"([@#])(?<word>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            MatchCollection matches = Regex.Matches(text, pattern);
            int countOfMirrorWords = 0;
            if (matches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                List<string> mirrorWords = new List<string>();
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    string firstWord = match.Groups["word"].Value;
                    string secondWord = match.Groups["secondWord"].Value;
                    string reversed = string.Join("", secondWord.Reverse());
                    if (firstWord == reversed)
                    {
                        countOfMirrorWords++;
                        mirrorWords.Add($"{firstWord} <=> {secondWord}");
                    }
                }
                if (countOfMirrorWords == 0)
                {
                    Console.WriteLine($"No mirror words!");
                    return;
                }
                else
                {
                    Console.WriteLine($"The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
            }
            if (countOfMirrorWords == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
        }
    }
}
