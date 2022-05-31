using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(string.Join("\r\n",
            //     Console.ReadLine()
            //   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //   .Select(double.Parse)
            //   .Select(x => x * 1.2)
            //   .ToArray()));

            List<double> productsWithVAT = Console.ReadLine()
          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
          .Select(double.Parse)
          .Select(x => x * 1.2)
          .ToList();
            productsWithVAT.ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
