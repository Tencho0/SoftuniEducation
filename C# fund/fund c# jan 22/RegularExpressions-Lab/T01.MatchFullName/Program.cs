using System;
using System.Text.RegularExpressions;

namespace T01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");
            MatchCollection matches = regex.Matches(Console.ReadLine());
            foreach (Match item in matches)
            {
                Console.Write(item.Value + " ");
            }
        }
    }
}
