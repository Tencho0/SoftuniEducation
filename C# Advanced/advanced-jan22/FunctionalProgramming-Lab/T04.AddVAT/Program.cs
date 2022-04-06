using System;
using System.Linq;

namespace T04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            //nums = nums.Select(x => x + x * 0.2).ToList();
            Func<double, double> vatadder = x => x + x * 0.2;
            nums = nums.Select(vatadder).ToList();
            nums.ForEach(x => Console.WriteLine($"{x:F2}"));


            //double[] nums = Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(double.Parse)
            //    .ToArray();
            //Func<double, double> func = x => x *= 1.2;
            //foreach (var num in nums.Select(x => func(x)))
            //{
            //    Console.WriteLine($"{num:F2}");
            //}
        }
    }
}
