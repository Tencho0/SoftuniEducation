using System;
using System.Text.RegularExpressions;

namespace T05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"[+-]*\d+([\.\d]*)";

            MatchCollection letters = Regex.Matches(input, lettersPattern);
            MatchCollection digits = Regex.Matches(input, digitsPattern);

        }
    }
}
