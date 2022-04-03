using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(.+)>(?<digits>\d{3})\|(?<lowlet>[a-z]{3})\|(?<uplet>[A-Z]{3})\|(?<symbols>[^><]{3})<\1";

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();
                Match match = Regex.Match(password, pattern);
                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    string digits = match.Groups["digits"].Value;
                    string lowerLetters = match.Groups["lowlet"].Value;
                    string upperLetters = match.Groups["uplet"].Value;
                    string symbols = match.Groups["symbols"].Value;
                    sb.Append(digits);
                    sb.Append(lowerLetters);
                    sb.Append(upperLetters);
                    sb.Append(symbols);
                    Console.WriteLine($"Password: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine($"Try another password!");
                }
            }
        }
    }
}
