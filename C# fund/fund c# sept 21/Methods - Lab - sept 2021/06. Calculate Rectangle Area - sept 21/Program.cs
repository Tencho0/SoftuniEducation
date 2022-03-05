using System;

namespace _06._Calculate_Rectangle_Area___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine(CalculatedArea(width,length));
        }
        static double CalculatedArea(double a, double b)
        {
            return a * b;
        }
    }
}
