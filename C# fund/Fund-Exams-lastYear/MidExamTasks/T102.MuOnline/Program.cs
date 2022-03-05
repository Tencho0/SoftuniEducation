using System;
using System.Collections.Generic;
using System.Linq;

namespace T102.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            int initialHealth = 100;
            int bitcoins = 0;
            int currRoom = 0;
            while (initialHealth > 0)
            {
                string[] currCmd = rooms[currRoom].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string monster = currCmd[0];
                int value = int.Parse(currCmd[1]);
                if (monster == "potion")
                {
                    int currHealth = initialHealth;
                    initialHealth += value;
                    if (initialHealth > 100)
                    {
                        initialHealth = 100;
                    }
                    int difference = initialHealth - currHealth;
                    Console.WriteLine($"You healed for {difference} hp.");
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }
                else if (monster == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    if (initialHealth - value <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {currRoom+1}");
                        return;
                    }
                    initialHealth -= value;
                    Console.WriteLine($"You slayed {monster}.");
                }
                currRoom++;
                if (currRoom == rooms.Count)
                {
                    break;
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}
