using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfFilm = Console.ReadLine();


            int totalStudents = 0;
            int totalStandard = 0;
            int totalKid = 0;

            while (nameOfFilm != "Finish")
            {
                int counterStudent = 0;
                int counterStandard = 0;
                int counterKid = 0;
                int freeSeats = int.Parse(Console.ReadLine());
                for (int i = 0; i < freeSeats; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "student":
                            counterStudent++;
                            break;
                        case "standard":
                            counterStandard++;
                            break;
                        case "kid":
                            counterKid++;
                            break;
                    }

                }
                totalStudents += counterStudent;
                totalStandard += counterStandard;
                totalKid += counterKid;
                double percentagesFull = (counterStudent + counterStandard + counterKid) / (double)freeSeats * 100;
                Console.WriteLine($"{nameOfFilm} - {percentagesFull:f2}% full.");
                nameOfFilm = Console.ReadLine();
            }
            int totalTickets = totalStudents + totalStandard + totalKid;
            Console.WriteLine($"Total tickets: {totalTickets}");
            double standardPercent = totalStandard / (double)totalTickets * 100;
            double studentPercent = totalStudents / (double)totalTickets * 100;
            double kidsPercent = totalKid / (double)totalTickets * 100;
            Console.WriteLine($"{studentPercent:f2}% student tickets.");
            Console.WriteLine($"{standardPercent:f2}% standard tickets.");
            Console.WriteLine($"{kidsPercent:f2}% kids tickets.");
        }
    }
}