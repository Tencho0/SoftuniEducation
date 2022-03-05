using System;

namespace T02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal x1 = decimal.Parse(Console.ReadLine());
            decimal y1 = decimal.Parse(Console.ReadLine());
            decimal x2 = decimal.Parse(Console.ReadLine());
            decimal y2 = decimal.Parse(Console.ReadLine());
            PrintClosestToTheCenterPoint(x1, y1, x2,y2);
        }
        static void PrintClosestToTheCenterPoint(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal firstSum = Math.Abs(x1) + Math.Abs(y1);
            decimal secondSum = Math.Abs(x2) + Math.Abs(y2);
            if (firstSum <= secondSum)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
