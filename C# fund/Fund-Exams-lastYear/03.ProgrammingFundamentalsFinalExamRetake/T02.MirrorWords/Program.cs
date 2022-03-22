using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace T02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary<string, string> mirrors = new Dictionary<string, string>();
            List<string> mirrors = new List<string>();

            string text = Console.ReadLine();
            string pattern = @"([@#]{1})([A-Za-z]{3,})\1{2}[A-Za-z]{3,}";
            MatchCollection matches = Regex.Matches(text, pattern);
            if (matches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (var item in matches)
                {

                }
            }
        }
    }
}
