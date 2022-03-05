using System;

namespace Courier_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string typeDelivery = Console.ReadLine();
            int kilometer = int.Parse(Console.ReadLine());

            double totalPrice = 0;

                if (weight < 1)
                {
                    totalPrice = 3 * kilometer / 100.0;
                }
                else if (weight >= 1 && weight < 10)
                {
                    totalPrice = 5 * kilometer / 100.0;
                }
                else if (weight >= 10 && weight < 40)
                {
                    totalPrice = 10 * kilometer / 100.0;
                }
                else if (weight >= 40 && weight < 90)
                {
                    totalPrice = 15 * kilometer / 100.0;
                }
                else if (weight >= 90 && weight < 150)
                {
                    totalPrice = 20 * kilometer / 100.0;
                }

            if (typeDelivery == "express")
            {
                if (weight < 1)
                {
                    totalPrice += weight * 0.8 * 3 * kilometer / 100.0;
                }
                else if (weight >= 1 && weight < 10)
                {
                    totalPrice += weight * 0.4 * 5 * kilometer / 100.0;
                }
                else if (weight >= 10 && weight < 40)
                {
                    totalPrice += weight * 0.05 * 10 * kilometer / 100.0;
                }
                else if (weight >= 40 && weight < 90)
                {
                    totalPrice += weight * 0.02 * 15 * kilometer / 100.0;
                }
                else if (weight >= 90 && weight < 150)
                {
                    totalPrice += weight * 0.01 * 20 * kilometer / 100.0;
                }
            }
            double moneyForDeliveryTotal = totalPrice;

            Console.WriteLine($"The delivery of your shipment with weight of {weight:F3} kg. would cost {moneyForDeliveryTotal:F2} lv.");
        }
    }
}
