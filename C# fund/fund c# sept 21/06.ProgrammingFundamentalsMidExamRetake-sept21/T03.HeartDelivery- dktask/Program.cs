using System;
using System.Linq;

namespace T03.HeartDelivery__dktask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            int currCupidPossition = 0;
            string cmd = Console.ReadLine();
            while (cmd != "Love!")
            {
                string[] cmdSplited = cmd.Split();
                int jump =int.Parse(cmdSplited[1]);
                if (currCupidPossition + jump >= neighborhood.Length)
                {
                    currCupidPossition = 0;
                }
                else
                {
                    currCupidPossition += jump;
                }
                neighborhood[currCupidPossition] -= 2;
                if (neighborhood[currCupidPossition] == 0)
                {
                    Console.WriteLine($"Place {currCupidPossition} has Valentine's day.");
                }
                if (neighborhood[currCupidPossition] < 0)
                {
                    Console.WriteLine($"Place {currCupidPossition} already had Valentine's day.");
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {currCupidPossition}.");
            if (!neighborhood.Any(number => number > 0))
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Count(number => number > 0)} places.");
            }
        }
    }
}
