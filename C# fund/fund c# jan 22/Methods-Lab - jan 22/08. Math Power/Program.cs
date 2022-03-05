using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(GiveBackTheResult(number, power));
        }

        private static double GiveBackTheResult(double number, double power)
        {
            return (double)Math.Pow(number, power);
        }
    }
}
