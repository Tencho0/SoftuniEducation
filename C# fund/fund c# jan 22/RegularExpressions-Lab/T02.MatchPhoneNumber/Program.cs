using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Regex regex = new Regex(@"[^ ]?\+359([ -])\d{1}(\1)\d{3}(\1)\d{4}\b");
            //string phoneNumbers = Console.ReadLine();
            //MatchCollection matches = regex.Matches(phoneNumbers);
            //var phoneMatches = matches
            //    .Cast<Match>()
            //    .Select(x => x.Value.Trim())
            //    .ToArray();

          //  var matches = Regex.Matches(Console.ReadLine(), @"(\+ ?359([ -])2(\2)\d{3}(\2)\d{4}\b)"); 
            var matches = Regex.Matches(Console.ReadLine(), @"[^ ]?\+359([ -])\d{1}(\1)\d{3}(\1)\d{4}\b");       
            var phoneMatches = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", phoneMatches));
        }
    }
}
