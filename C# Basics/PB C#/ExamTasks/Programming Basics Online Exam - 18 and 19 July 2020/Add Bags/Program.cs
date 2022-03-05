using System;

namespace Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMore20kg = double.Parse(Console.ReadLine());
            double weightLuggage = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int luggages = int.Parse(Console.ReadLine());

            double priceForLuggage = 0;
            if (weightLuggage > 20)
            {
                priceForLuggage = priceMore20kg;
            }
            else if (weightLuggage >= 10)
            {
                priceForLuggage = priceMore20kg * 0.5;
            }
            else
            {
                priceForLuggage = priceMore20kg * 0.2;
            }

            if (days > 30)
            {
                priceForLuggage += priceForLuggage * 0.1;
            }
            else if (days > 7)
            {
                priceForLuggage += priceForLuggage * 0.15;
            }
            else
            {
                priceForLuggage += priceForLuggage * 0.4;
            }
            double totalSumForLuggage = priceForLuggage * luggages;
            Console.WriteLine($"The total price of bags is: {totalSumForLuggage:f2} lv. ");
        }
    }
}
