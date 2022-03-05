using System;

namespace newhaus2
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int countOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double finalMoney = 0;
            const double rosesPricePer1 = 5;
            const double dahliasPricePer1 = 3.8;
            const double tulipsPricePer1 = 2.8;
            const double narcissusPricePer1 = 3;
            const double gladiolusPricePer1 = 2.5;

            switch(flowerType)
            {
                case "Roses":
                    if (countOfFlowers > 80)
                    {
                        finalMoney -= countOfFlowers * rosesPricePer1 * 0.1;
                    }
                        finalMoney += countOfFlowers * rosesPricePer1;
                        break;

                case "Dahlias":

                    if (countOfFlowers > 90)
                    {
                        finalMoney -= countOfFlowers * dahliasPricePer1 * 0.15;
                    }
                        finalMoney += countOfFlowers * dahliasPricePer1;
                    break;

                case "Tulips":

                    if (countOfFlowers > 80)
                    {
                        finalMoney -= countOfFlowers * tulipsPricePer1 * 0.15;
                    }
                        finalMoney += countOfFlowers * tulipsPricePer1;
                    break;

                    case "Narcissus":

                    if (countOfFlowers < 120)
                    {
                        finalMoney += countOfFlowers * narcissusPricePer1 * 0.15;
                    }
                        finalMoney += countOfFlowers * narcissusPricePer1;
                    break;
                case "Gladiolus":
                    if (countOfFlowers < 80)
                    {
                        finalMoney += countOfFlowers * gladiolusPricePer1 * 0.2;
                    }
                        finalMoney += countOfFlowers * gladiolusPricePer1;
                    break;
            }
            if (budget >= finalMoney)
            {
                double enoughtMoney = budget - finalMoney;
                Console.WriteLine($"Hey, you have a great garden with {countOfFlowers} {flowerType} and {enoughtMoney:F2} leva left.");
            }
            else
            {
                double neededMoney = finalMoney - budget;
                Console.WriteLine($"Not enough money, you need {neededMoney:F2} leva more.");
            }
        }
    }
}
