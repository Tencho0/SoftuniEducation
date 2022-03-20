using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string healthPattern = @"[^\+\-\*\/\.\,0-9 ]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplicationPattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";

            string input = Console.ReadLine();
            // string[]demons = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).OrderBy(x=>x).ToArray();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();
            for (int i = 0; i < demons.Length; i++)
            {
                string currDemon = demons[i];

                MatchCollection healthMatched = Regex.Matches(currDemon, healthPattern);
                long health = 0;
                foreach (Match match in healthMatched)
                {
                    char currCh = char.Parse(match.ToString());
                    health += currCh;
                }

                double damage = 0;
                MatchCollection damageMatched = Regex.Matches(currDemon, damagePattern);
                foreach (Match match in damageMatched)
                {
                    double currDamage = double.Parse(match.ToString());
                    damage += currDamage;
                }

                MatchCollection multiplicationMatches = Regex.Matches(currDemon, multiplicationPattern);
                foreach (Match match in multiplicationMatches)
                {
                    char currOperator = char.Parse(match.ToString());
                    if (currOperator== '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{currDemon} - {health} health, {damage:F2} damage");
            }



            //var arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            //Dictionary<string, Dictionary<int, double>> demons = new Dictionary<string, Dictionary<int,double>>();
            //foreach (string input in arr)
            //{
            //    int health = 0;
            //    double damage = 0;
            //    //foreach (char currLetter in input)
            //    //{
            //    //    if (char.IsLetter(currLetter))
            //    //    {
            //    //        health += currLetter;
            //    //    }
            //    //}
            //    string charpattern = @"[^\d\+\-\/\*\.\, ]";
            //    MatchCollection matchesChars = Regex.Matches(input, charpattern);
            //    foreach (Match match in matchesChars)
            //    {
            //        health += char.Parse(match.Value);
            //    }

            //    string pattern = @"-?\d+\.?\d*";
            //    string mdPattern = @"[*\/]";
            //    MatchCollection matches = Regex.Matches(input, pattern);
            //    MatchCollection matchesForMD = Regex.Matches(input, mdPattern);
            //    foreach (Match match in matches)
            //    {
            //        damage += (double.Parse(match.Value));
            //    }
            //    foreach (Match match in matchesForMD)
            //    {
            //        if (match.Value == "*")
            //        {
            //            damage *= 2;
            //        }
            //        else
            //        {
            //            damage /= 2;
            //        }
            //    }
            //    demons[input] = new Dictionary<int, double>();
            //    demons[input][health] = damage;
            //}
            //foreach (var item in demons.OrderBy(x=> x.Key))
            //{
            //    int health = 0;
            //    double damage = 0;
            //    string input = item.Key;
            //    foreach (var item2 in item.Value)
            //    {
            //        health = item2.Key;
            //        damage = item2.Value;
            //    }
            //    Console.WriteLine($"{input} - {health} health, {damage:F2} damage");
            //}
        }
    }
}
