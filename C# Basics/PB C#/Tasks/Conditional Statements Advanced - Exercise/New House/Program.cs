using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

                const double rosesPricePer1 = 5;
                const double dahliasPricePer1 = 3.8;
                const double tulipsPricePer1 = 2.8;
                const double nnarcissusPricePer1 = 3;
                const double gladiolusPricePer1 = 2.5;
            double discount = 0;
            double flowerPrice = 0;
            
                if ("Roses"):
                    {
                    if(num >= 80)
                    {
                        flowerPrice = rosesPricePer1 * num;
                        discount = 0.1;
                    }
                    break;
                case ("Dahlias"):
                    if(num >= 90)
                    {
                        flowerPrice = dahliasPricePer1 * num;
                        discount = 0.15;
                    }
                    break;
                case ("Tulips"):
                    if (num >= 80)
                    {
                        flowerPrice = tulipsPricePer1 * num;
                        discount = 0.15;
                    }
                    break;
                case ("Narcissus"):
                    if (num < 120)
                    {
                        flowerPrice = nnarcissusPricePer1 * num;
                        discount = -0.15;
                    }
                    break;
                case ("Gladiolus"):
                    if (num < 80)
                    {
                        flowerPrice = gladiolusPricePer1 * num;
                        discount = -0.2;
                    }
                    break;
            double neededMoney = budget - (num * flowerPrice * discount);
            if(neededMoney >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {num} {flower} and {neededMoney} leva left.");
            }
            else if(neededMoney < 0)
            {
                neededMoney = Math.Abs(neededMoney);
                Console.WriteLine($"Not enough money, you need {neededMoney} leva more.");
            }
        }
    }
}
