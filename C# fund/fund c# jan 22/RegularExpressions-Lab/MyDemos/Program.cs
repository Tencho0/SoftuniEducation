using System;
using System.Text.RegularExpressions;

namespace MyDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Regex regex = new Regex(@"[A-Za-z]+[\d]+@[a-z].*[a-z]+");
            //Match match = regex.Match("valid123@gmail.com");

            // Regex regex = new Regex(@"([A-Z][a-z]+) ([A-Z][a-z]+)");
            Regex regex = new Regex(@"[A-Z][a-z]+ [A-Z][a-z]+");

            string[] splited = regex.Split("Pesho Petrow e brat na Misho Petrow");
            Console.WriteLine(string.Join("\n", splited));

            //string replaced = regex.Replace("Pesho Petrow e brat na Misho Petrow", "*******");
            //Console.WriteLine(replaced);

            //MatchCollection matches = regex.Matches("Pesho Petrow e brat na Misho Petrow");
            //Console.WriteLine(matches[0].Groups.Count);
            //foreach (Match currMatch in matches)
            //{
            //    Console.WriteLine("First Name: " + currMatch.Groups[1]);
            //    Console.WriteLine("Last Name: " + currMatch.Groups[2]);
            //    Console.WriteLine(currMatch.Success);
            //    Console.WriteLine(currMatch.Value);
            //    Console.WriteLine(currMatch.Index);
            //    Console.WriteLine();
            //}

            // Match match = regex.Match("Pesho Petrow e brat na Misho Petrow");
            //Console.WriteLine(match.Success);
            //Console.WriteLine(match.Value);
            //Console.WriteLine(match.Index);
        }
    }
}
