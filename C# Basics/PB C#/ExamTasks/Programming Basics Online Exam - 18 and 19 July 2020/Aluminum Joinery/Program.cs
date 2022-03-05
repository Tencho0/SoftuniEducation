using System;

namespace Aluminum_Joinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numJoinery = int.Parse(Console.ReadLine());
            string kindOfJoinery = Console.ReadLine();
            string delivery = Console.ReadLine();

            const double DELIVERYPRICE = 60.0;
            double priceForJoinery = 0.0;

            if (numJoinery < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }

            if (kindOfJoinery == "90X130")
            {
                priceForJoinery = numJoinery * 110;
                if (numJoinery > 60)
                {
                    priceForJoinery -= priceForJoinery * 0.08;
                }
                else if (numJoinery > 30)
                {
                    priceForJoinery -= priceForJoinery * 0.05;
                }
            }
            else if (kindOfJoinery == "100X150")
            {
                priceForJoinery = numJoinery * 140;
                if (numJoinery > 80)
                {
                    priceForJoinery -= priceForJoinery * 0.1;
                }
                else if (numJoinery > 40)
                {
                    priceForJoinery -= priceForJoinery * 0.06;
                }
            }
            else if (kindOfJoinery == "130X180")
            {
                priceForJoinery = numJoinery * 190;
                if (numJoinery > 50)
                {
                    priceForJoinery -= priceForJoinery * 0.12;
                }
                else if (numJoinery > 20)
                {
                    priceForJoinery -= priceForJoinery * 0.07;
                }
            }
            else if (kindOfJoinery == "200X300")
            {
                priceForJoinery = numJoinery * 250;
                if (numJoinery > 50)
                {
                    priceForJoinery -= priceForJoinery * 0.14;
                }
                else if (numJoinery > 25)
                {
                    priceForJoinery -= priceForJoinery * 0.09;
                }
            }

            if (delivery == "With delivery")
            {
                priceForJoinery += DELIVERYPRICE;
            }

            if (numJoinery > 99)
            {
                priceForJoinery *= 0.96;
            }
            Console.WriteLine($"{priceForJoinery:F2} BGN");
        }
    }
}
