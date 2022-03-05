using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string monat = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartmentPrice = 0;
            switch (monat)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    if(nights > 14)
                    {
                        studioPrice = 50 - 50 * 0.3;
                        apartmentPrice = 65 - 65 * 0.1;
                    }
                    else if(nights > 7)
                    {
                        studioPrice = 50 - 50 * 0.05;
                    }
                    break;

                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartmentPrice = 68.7;
                    if(nights > 14)
                    {
                        studioPrice = 75.2 - 75.2 * 0.2;
                        apartmentPrice = 68.7 - 68.7 * 0.1;
                    }
                    break;

                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    if (nights > 14)
                    {
                        apartmentPrice = 77 - 77 * 0.1;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {apartmentPrice * nights:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice * nights:F2} lv.");

        }
    }
}
