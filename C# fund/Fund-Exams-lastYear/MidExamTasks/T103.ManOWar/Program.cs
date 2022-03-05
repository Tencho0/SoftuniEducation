using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine()
               .Split('>', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList();

            int maxHealth = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "Retire")
            {
                string[] givenCmd = command.Split();
                string currCmd = givenCmd[0];
                if (currCmd == "Fire")
                {
                    AttackTheWarship(warShip, givenCmd);
                }
                else if (currCmd == "Defend")
                {
                    DefendTheShip(pirateShip, givenCmd);
                }
                else if (currCmd == "Repair")
                {
                    RepairTheShip(pirateShip, givenCmd, maxHealth);
                }
                else if (currCmd == "Status")
                {
                    PrintTheStatus(pirateShip, maxHealth);
                }
                command = Console.ReadLine();
            }
            PrintTheResult(pirateShip, warShip);
        }
        public static bool IsIndexValid(int index, List<int> ship)
        {
            return index >= 0 && index < ship.Count;
        }
        public static bool AreIndicesValid(int startIndex, int endIndex, List<int> ship)
        {
            return startIndex >= 0 && startIndex < ship.Count && endIndex >= 0 && endIndex < ship.Count;
        }
        public static void PrintTheResult(List<int> pirateShip, List<int> warShip)
        {
            if (pirateShip.Count > 0 && warShip.Count > 0)
            {
                Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                Console.WriteLine($"Warship status: {warShip.Sum()}");
            }
        }
        public static void PrintTheStatus(List<int> pirateShip, int maxHealth)
        {
            int counter = 0;
            foreach (var item in pirateShip)
            {
                if (item < maxHealth * 0.2)
                {
                    counter++;
                }
            }
            Console.WriteLine($"{counter} sections need repair.");
        }
        public static void RepairTheShip(List<int> pirateShip, string[] givenCmd, int maxHealth)
        {
            int index = int.Parse(givenCmd[1]);
            int health = int.Parse(givenCmd[2]);
            if (IsIndexValid(index, pirateShip))
            {
                pirateShip[index] += health;
                if (pirateShip[index] > maxHealth)
                {
                    pirateShip[index] = maxHealth;
                }
            }
        }
        public static void AttackTheWarship(List<int> warShip, string[] givenCmd)
        {
            int index = int.Parse(givenCmd[1]);
            int damage = int.Parse(givenCmd[2]);
            if (IsIndexValid(index, warShip))
            {
                warShip[index] -= damage;
                if (warShip[index] <= 0)
                {
                    warShip.RemoveAt(index);
                    Console.WriteLine($"You won! The enemy ship has sunken.");
                    Environment.Exit(0);
                }
            }
        }
        public static void DefendTheShip(List<int> pirateShip, string[] givenCmd)
        {
            int startIndex = int.Parse(givenCmd[1]);
            int endIndex = int.Parse(givenCmd[2]);
            int damage = int.Parse(givenCmd[3]);
            if (AreIndicesValid(startIndex, endIndex, pirateShip))
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    pirateShip[i] -= damage;
                    if (pirateShip[i] <= 0)
                    {
                        Console.WriteLine($"You lost! The pirate ship has sunken.");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
