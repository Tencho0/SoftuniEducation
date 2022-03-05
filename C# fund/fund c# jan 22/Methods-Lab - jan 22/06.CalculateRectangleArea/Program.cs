using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(AreaOfTheRectangle(width, height));
        }
        public static double AreaOfTheRectangle(double a, double b)
        {
            return a * b;
        }
    }
}
