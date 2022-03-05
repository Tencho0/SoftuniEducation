using System;

namespace Hair_Salon
{
    class Program
    {
        static void Main(string[] args)
        {
            double goalMoney = double.Parse(Console.ReadLine());
            string cutOrColor = Console.ReadLine();
            double currMoney = 0;
            while (currMoney <= goalMoney)
            {
                if (cutOrColor == "closed")
                {
                    break;
                }
                string typeOfCutColor = Console.ReadLine();
                if (cutOrColor == "haircut")
                {
                    if (typeOfCutColor == "mens")
                    {
                        currMoney += 15;
                    }
                    else if (typeOfCutColor == "ladies")
                    {
                        currMoney += 20;
                    }
                    else if (typeOfCutColor == "kids")
                    {
                        currMoney += 10;
                    }
                }
                else if (cutOrColor == "color")
                {
                    if (typeOfCutColor == "touch up")
                    {
                        currMoney += 20;
                    }
                    else if (typeOfCutColor == "full color")
                    {
                        currMoney += 30;
                    }
                }
                if (currMoney >= goalMoney)
                {
                    break;
                }
                cutOrColor = Console.ReadLine();
                if (cutOrColor == "closed")
                {
                    break;
                }
            }
            if (currMoney >= goalMoney)
            {
                Console.WriteLine($"You have reached your target for the day!");
            }
            else
            {
                double difference = goalMoney - currMoney;
                Console.WriteLine($"Target not reached! You need {difference}lv. more.");
            }
            Console.WriteLine($"Earned money: {currMoney}lv.");
        }
    }
}
