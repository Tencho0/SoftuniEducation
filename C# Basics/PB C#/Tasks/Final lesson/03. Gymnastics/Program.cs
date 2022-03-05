using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();


            double score = 0;

            switch (country)
            {
                case "Russia":
                    switch (instrument)
                    {
                        case "ribbon":
                            score = 9.100 + 9.400;
                            break;
                        case "hoop":
                            score = 9.300 + 9.800;
                            break;
                        case "rope":
                            score = 9.600 + 9.000;
                            break;
                    }
                    break;
                case "Bulgaria":
                    switch (instrument)
                    {
                        case "ribbon":
                            score = 9.600 + 9.400;
                            break;
                        case "hoop":
                            score = 9.550 + 9.750;
                            break;
                        case "rope":
                            score = 9.500 + 9.400;
                            break;
                    }
                    break;
                case "Italy":
                    switch (instrument)
                    {
                        case "ribbon":
                            score = 9.200 + 9.500;
                            break;
                        case "hoop":
                            score = 9.450 + 9.350;
                            break;
                        case "rope":
                            score = 9.700 + 9.150;
                            break;
                    }
                    break;
            }

            double percentToMaxPoints = (20 - score) / 20 * 100;

            Console.WriteLine($"The team of {country} get {score:f3} on {instrument}.");
            Console.WriteLine($"{percentToMaxPoints:f2}%");

        }
    }
}
