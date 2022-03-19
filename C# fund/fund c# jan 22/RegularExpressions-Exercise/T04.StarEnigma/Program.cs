using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*?:(?<population>[\d]+)[^@\-!:>]*?!(?<attackType>[A|D])![^@\-!:>]*?->(?<soldiers>\d+)";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string encrypted = Console.ReadLine();
                string decrypted = DecryptMessage(encrypted);
                Match match = Regex.Match(decrypted, pattern);
                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string attackType = match.Groups["attackType"].Value;
                    int soldiers = int.Parse(match.Groups["soldiers"].Value);
                    if (attackType == "A")
                    {
                        attackPlanets.Add(planet);
                    }
                    else
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }
            PrintResult(attackPlanets, destroyedPlanets);
        }

        private static void PrintResult(List<string> attackPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackPlanets.Count}");
            foreach (var currPlanet in attackPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {currPlanet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var currPlanet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {currPlanet}");
            }
        }

        static string DecryptMessage(string encrypted)
        {
            int count = TakeCount(encrypted);
            StringBuilder sb = new StringBuilder();
            foreach (char currCh in encrypted)
            {
                char currLetter = (char)(currCh - count);
                sb.Append(currLetter);
            }
            return sb.ToString();
        }
        static int TakeCount(string encrypted)
        {
            string pattern = @"[star]";
            MatchCollection matches = Regex.Matches(encrypted, pattern, RegexOptions.IgnoreCase);
            return matches.Count;
        }
    }
}
