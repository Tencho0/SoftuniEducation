using System;

namespace _6___Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string sport = "";
            int winTimes = 0;
            int loseTimes = 0;
            double money2 = 0;
            int finisher = 1;
            for (int i = 1; i <= days; i++)
            {
                double money = 0;
                winTimes = 0;
                loseTimes = 0;
                while (finisher <= days)
                {
                    sport = Console.ReadLine();
                    if (sport == "Finish")
                    {
                        finisher++;
                        break;
                    }
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        winTimes++;
                        money += 20;
                    }
                    else
                    {
                        loseTimes++;
                    }
                }
                if (winTimes > loseTimes)
                {
                    money *= 1.1;
                }
                money2 += money;
            }
            if (winTimes > loseTimes)
            {
                money2 *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {money2:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {money2:F2}");
            }
        }
    }
}
