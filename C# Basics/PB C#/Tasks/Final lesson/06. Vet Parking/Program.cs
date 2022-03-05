using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDays = int.Parse(Console.ReadLine());
            int numOfHours = int.Parse(Console.ReadLine());

            double total = 0;

            for (int day = 1; day <= numOfDays; day++)
            {
                double totalForTheDay = 0;

                for (int hour = 1; hour <= numOfHours; hour++)
                {
                    if (day % 2 != 0 && hour % 2 == 0)
                    {
                        totalForTheDay += 1.25;
                    }
                    else if (day % 2 == 0 && hour % 2 != 0)
                    {
                        totalForTheDay += 2.50;
                    }
                    else
                    {
                        totalForTheDay += 1;
                    }
                }

                total += totalForTheDay;
                Console.WriteLine($"Day: {day} - {totalForTheDay:f2} leva");
            }

            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
