using System;

namespace _03._Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            int companies = int.Parse(Console.ReadLine());
            string highestAveragePassengerName = "";
            int highestAveragePassengerCounter = int.MinValue;
            for (int i = 0; i < companies; i++)
            {
                int passegerNumbers = 0;
                int counter = 0;
                string name = Console.ReadLine();
                string passenger = Console.ReadLine();
                while (passenger != "End")
                {
                    int passengerNum = int.Parse(passenger);
                    passegerNumbers += passengerNum;
                    counter++;
                    passenger = Console.ReadLine();
                }
                int averagePassengers = 0;
                averagePassengers = passegerNumbers / counter;
                Console.WriteLine($"{name}: {averagePassengers}");
                if (highestAveragePassengerCounter < averagePassengers)
                {
                    highestAveragePassengerName = name;
                    highestAveragePassengerCounter = averagePassengers;
                }
            }
            Console.WriteLine($"{highestAveragePassengerName} has most passengers per flight: {highestAveragePassengerCounter}");
        }
    }
}
