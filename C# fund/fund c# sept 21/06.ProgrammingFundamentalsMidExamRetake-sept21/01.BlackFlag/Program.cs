using System;
using System.Numerics;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;
            double halfDayPlunder = dailyPlunder *0.5;
            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    totalPlunder += halfDayPlunder;
                }
                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percent = totalPlunder / expectedPlunder * 100.0;
                Console.WriteLine($"Collected only {percent:f2}% of the plunder.");
            }
        }
    }
}
