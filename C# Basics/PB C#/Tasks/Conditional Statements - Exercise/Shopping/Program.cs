using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardNum = int.Parse(Console.ReadLine());
            int cpuNum = int.Parse(Console.ReadLine());
            int ramNum = int.Parse(Console.ReadLine());

            int videoCardPrice = 250;
            double cpuPrice = videoCardNum * videoCardPrice * 0.35;
            double ramPrice = videoCardNum * videoCardPrice * 0.1;

            double totalPrice = videoCardNum * videoCardPrice + cpuNum * cpuPrice + ramNum * ramPrice;
            if (videoCardNum > cpuNum)
            {
                totalPrice *= 0.85;
            }
            if (budget >= totalPrice)
            {
                double diffrence = budget - totalPrice;
                Console.WriteLine($"You have {diffrence:F2} leva left!");
            }
            else
            {
                double diffrence = totalPrice - budget;
                Console.WriteLine($"Not enough money! You need {diffrence:F2} leva more!");
            }
        }
    }
}
