using System;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            n = n / 1000;
            Console.WriteLine($"{n:f2}");
        }
    }
}
