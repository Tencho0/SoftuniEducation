using System;
using System.Text.RegularExpressions;

namespace T02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productPattern = @"(@#+)(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)";
            string digitsPattern = @"\d";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match product = Regex.Match(input, productPattern);
                MatchCollection digits = Regex.Matches(input, digitsPattern);
                if (product.Success)
                {
                    if (digits.Count == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        string productGroup = string.Empty;
                        foreach (Match digit in digits)
                        {
                            productGroup += digit.ToString();
                        }
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
