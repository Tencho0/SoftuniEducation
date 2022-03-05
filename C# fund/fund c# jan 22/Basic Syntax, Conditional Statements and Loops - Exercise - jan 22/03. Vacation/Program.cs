using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string day = Console.ReadLine();
            double pricePerStudent = 0;
            double totalPriceWithoutDiscount = 0;
            double totalPriceWithDiscount = 0;

            if (typeOfPeople == "Students")
            {
                if (day == "Friday")
                {
                    pricePerStudent = 8.45;
                }
                else if (day == "Saturday")
                {
                    pricePerStudent = 9.8;
                }
                else if (day == "Sunday")
                {
                    pricePerStudent = 10.46;
                }
            }
            else if (typeOfPeople == "Business")
            {
                if (day == "Friday")
                {
                    pricePerStudent = 10.90;
                }
                else if (day == "Saturday")
                {
                    pricePerStudent = 15.60;
                }
                else if (day == "Sunday")
                {
                    pricePerStudent = 16;
                }
            }
            else if (typeOfPeople == "Regular")
            {
                if (day == "Friday")
                {
                    pricePerStudent = 15;
                }
                else if (day == "Saturday")
                {
                    pricePerStudent = 20;
                }
                else if (day == "Sunday")
                {
                    pricePerStudent = 22.50;
                }
            }

            totalPriceWithoutDiscount = countOfPeople * pricePerStudent;

            if (typeOfPeople == "Students")
            {
                if (countOfPeople >= 30)
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount * 0.85;
                }
                else
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount;
                }
            }
            else if (typeOfPeople == "Business")
            {
                if (countOfPeople >= 100)
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount - (10 * pricePerStudent);
                }
                else
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount;
                }
            }
            else if (typeOfPeople == "Regular")
            {
                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount * 0.95;
                }
                else
                {
                    totalPriceWithDiscount = totalPriceWithoutDiscount;
                }
            }
            Console.WriteLine($"Total price: {totalPriceWithDiscount:F2}");
        }
    }
}
