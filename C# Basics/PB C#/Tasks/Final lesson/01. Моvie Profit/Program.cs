using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int numOfTickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int cinemaPercent = int.Parse(Console.ReadLine()); // 7


            double totalIncome = days * numOfTickets * ticketPrice;

            double cinemaIncome = totalIncome * ((double)cinemaPercent / 100);

            double studioIncome = totalIncome - cinemaIncome;

            Console.WriteLine($"The profit from the movie {movieName} is {studioIncome:f2} lv.");

        }
    }
}
