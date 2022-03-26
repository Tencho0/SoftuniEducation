using System;

namespace _01._Videocards
{
    class Program
    {
        static void Main(string[] args)
        {
            int videocardsCounter = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hoursOfWorking = days * 8 * workers;
            int hoursOfMaking = videocardsCounter * 3;
            double incomeFromOrders = videocardsCounter * 110.1;
            double possibleIncome = (hoursOfWorking / 3) * 110.1;
            double difference = 0;

            if (hoursOfMaking <= hoursOfWorking)
            {
                difference = possibleIncome - incomeFromOrders;
                Console.WriteLine($"Profit: {difference:F2} BGN");
            }
            else
            {
                difference = incomeFromOrders - possibleIncome;
                Console.WriteLine($"Loss: {difference:F2} BGN");
            }
        }
    }
}
