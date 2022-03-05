using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split('|');
            int currHealt = 100;
            int totalBitcoins = 0;
            int expectedRooms = 0;
            for (int i = 1; i <= array.Length; i++)
            {
                string[] currMonster = array[i - 1].Split();
                string command = currMonster[0];
                int healthDamageOrIncome = int.Parse(currMonster[1]);
                if (command == "potion")
                {
                    int currPredictedHealth = currHealt + healthDamageOrIncome;
                    if (currPredictedHealth <= 100)
                    {
                        Console.WriteLine($"You healed for {healthDamageOrIncome} hp.");
                        currHealt = currPredictedHealth;
                    }
                    else
                    {
                        int difference = 100 - currHealt;
                        Console.WriteLine($"You healed for {difference} hp.");
                        currHealt = 100;
                    }
                    Console.WriteLine($"Current health: {currHealt} hp.");
                }
                else if (command == "chest")
                {
                    totalBitcoins += healthDamageOrIncome;
                    Console.WriteLine($"You found {healthDamageOrIncome} bitcoins.");
                }
                else
                {
                    int currHealthPrediction = currHealt - healthDamageOrIncome;
                    if (currHealthPrediction <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i}");
                        break;
                    }
                    currHealt = currHealthPrediction;
                    Console.WriteLine($"You slayed {command}.");
                }
                expectedRooms++;
            }
            if (expectedRooms == array.Length)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {totalBitcoins}");
                Console.WriteLine($"Health: {currHealt}");
            }
        }
    }
}
