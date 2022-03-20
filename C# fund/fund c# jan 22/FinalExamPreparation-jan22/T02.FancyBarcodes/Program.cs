using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@([#]+)[A-Z][A-Za-z\d]{4,}[A-Z]@#+";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    bool isGivenCode = false;
                    StringBuilder sb = new StringBuilder();
                    foreach (char digit in match.ToString())
                    {
                        if (char.IsDigit(digit))
                        {
                            sb.Append(digit);
                            isGivenCode = true;
                        }
                    }
                    if (isGivenCode)
                    {
                        Console.WriteLine($"Product group: {sb.ToString().Trim()}");
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
