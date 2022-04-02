using System;
using System.Text.RegularExpressions;

namespace T02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@#+)(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])@#+";
            string digitsPattern = @"[\d]";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                MatchCollection digits = Regex.Matches(input, digitsPattern);
                if (match.Success)
                {
                    string productGroup = string.Empty;
                    foreach (Match digit in digits)
                    {
                        productGroup += digit;
                    }
                    if (productGroup.Length > 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}
