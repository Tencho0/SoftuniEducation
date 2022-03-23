using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productPattern = @"@#+(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])@#+";
            string digitsPattern = @"[\d]";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, productPattern);
                if (match.Success)
                {
                    MatchCollection digits = Regex.Matches(input, digitsPattern);
                    if (digits.Count> 0)
                    {
                        StringBuilder barcode = new StringBuilder();
                        foreach (Match digit in digits)
                        {
                            barcode.Append(digit);
                        }
                        Console.WriteLine($"Product group: {barcode}");
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
