using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            const double roomForOnePersonPrice= 18.00;
            const double apartmentPrice = 25.00;
            const double presidentApartmentPrice = 35.00;

            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string mark = Console.ReadLine();
            int nights = days - 1;
            double priceForRoom = 0;
            switch(room)
            {
                case "room for one person":
                    priceForRoom = roomForOnePersonPrice * nights;
                    break;
                case "apartment":
                    if(days < 10)
                    {
                        priceForRoom = apartmentPrice * nights * 0.7;
                    }
                    else if (days < 15)
                    {
                        priceForRoom = apartmentPrice * nights * 0.65;
                    }
                    else
                    {
                        priceForRoom = apartmentPrice * nights * 0.5;
                    }
                    break;
                case "president apartment":

                    if (days < 10)
                    {
                        priceForRoom = presidentApartmentPrice * nights * 0.9;
                    }
                    else if (days < 15)
                    {
                        priceForRoom = presidentApartmentPrice * nights * 0.85;
                    }
                    else
                    {
                        priceForRoom = presidentApartmentPrice * nights * 0.8;
                    }
                    break;
            }
            if(mark == "positive")
            {
                priceForRoom += priceForRoom * 0.25;
            }
            else
            {
                priceForRoom -= priceForRoom * 0.1;
            }
            Console.WriteLine($"{priceForRoom:f2}");
        }
    }
}
