using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var patternForName =new Regex(@"(?<name>[A-za-z]+)");
            var patternForDigits =new Regex(@"(?<distance>\d+)");
            var sumOfDigits = 0;
            var participants = new Dictionary<string, int>();
            var names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection matchedNames = patternForName.Matches(input);
                MatchCollection matchedDigits = patternForDigits.Matches(input);
                var currName = string.Join("", matchedNames);
                var currDigit = string.Join("", matchedDigits);
                sumOfDigits = 0;
                for (int i = 0; i < currDigit.Length; i++)
                {
                    sumOfDigits += int.Parse(currDigit[i].ToString());

                }
                if (names.Contains(currName))
                {
                    if (!participants.ContainsKey(currName))
                    {
                        participants.Add(currName, sumOfDigits);
                    }
                    else
                    {
                        participants[currName] += sumOfDigits;
                    }
                }
                input = Console.ReadLine();
            }
            var winners = participants.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x=> x.Value).Take(2).OrderBy(x=> x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);
            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");
            }
            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }
            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
            //string input = Console.ReadLine();
            //Dictionary<string, int> players = new Dictionary<string, int>();

            //while (input != "end of race")
            //{
            //    int totalSum = 0;
            //    MatchCollection matches = regex.Matches(input);
            //    foreach (Match match in matches)
            //    {
            //        string name = match.Groups["name"].Value;
            //        totalSum += int.Parse(match.Groups["distance"].Value);
            //        if (players.ContainsKey(name))
            //        {
            //            players[name] += totalSum;
            //        }
            //        else
            //        {
            //            players[name] = totalSum;
            //        }
            //    }
            //    input = Console.ReadLine();
            //}
            //int possition = 0;
            //players = (Dictionary<string, int>)players.OrderByDescending(x => x.Value);

        }
    }
}
