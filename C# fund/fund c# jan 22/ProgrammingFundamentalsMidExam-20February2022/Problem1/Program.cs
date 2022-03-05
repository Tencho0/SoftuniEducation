using System;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDay = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int biscuitsPerMonth = int.Parse(Console.ReadLine());

            int totalBicuitsPerDay = biscuitsPerDay * workers;
            int totalBiscuits = 0;
            for (int i = 1; i <= 30; i++)
            {
                totalBiscuits += totalBicuitsPerDay;
                if (i % 3 == 0)
                {
                    totalBiscuits -= totalBicuitsPerDay;
                    totalBiscuits += (int)(Math.Floor(totalBicuitsPerDay * 0.75));
                }
            }
            Console.WriteLine($"You have produced {totalBiscuits} biscuits for the past month.");
           
            int different = (totalBiscuits - biscuitsPerMonth);
            if (totalBiscuits > biscuitsPerMonth)
            {
                double percentage = (1.0 * different / biscuitsPerMonth) * 100.0;
                Console.WriteLine($"You produce {percentage:F2} percent more biscuits.");
            }
            else
            {
                different = biscuitsPerMonth - totalBiscuits;
                double percentage = (1.0 * different / biscuitsPerMonth) * 100.0;
                Console.WriteLine($"You produce {percentage:F2} percent less biscuits.");
            }
        }
    }
}
