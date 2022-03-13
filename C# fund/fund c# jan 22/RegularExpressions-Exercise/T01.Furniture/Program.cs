using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<furniture>[A-Za-z]+)<<(?<price>\d+(\.*)\d*)!(?<quantity>\d+)\b");
            string cmd = Console.ReadLine();
            decimal totalPrice = 0;
            List<string> furnituresNames = new List<string>();
            while (cmd != "Purchase")
            {
                Match match = regex.Match(cmd);
                if (match.Success)
                {
                    string furniture = match.Groups["furniture"].Value;
                    decimal pricePerOne = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    furnituresNames.Add(furniture);
                    totalPrice += (pricePerOne * quantity);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            if (furnituresNames.Count>0)
            {
                Console.WriteLine(string.Join("\n", furnituresNames));
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
