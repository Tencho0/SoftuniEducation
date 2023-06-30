namespace T01Trains
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var arrival = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .OrderBy(n => n)
                .ToArray();

            var departure = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(FindMinPlatforms(arrival, departure));
        }

        private static int FindMinPlatforms(double[] arrival, double[] departure)
        {
            var totalPlatforms = 0;
            var platforms = 0;

            var arrivalIdx = 0;
            var departureIdx = 0;

            while (arrivalIdx < arrival.Length)
            {
                var arrivalTime = arrival[arrivalIdx];
                var departureTime = departure[departureIdx];

                if (arrivalTime < departureTime)
                {
                    platforms++;
                    arrivalIdx++;
                    totalPlatforms = Math.Max(totalPlatforms, platforms);
                }
                else
                {
                    departureIdx++;
                    platforms--;
                }
            }

            return totalPlatforms;
        }
    }
}
