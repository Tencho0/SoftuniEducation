using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warship = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "Retire")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                if (currCommand == "Fire")
                {
                    AttackTheWarship(givenCommand, warship);
                }
                else if (currCommand == "Defend")
                {
                    SubstractionPirateShip(pirateShip, givenCommand);
                }
                else if (currCommand == "Repair")
                {
                    RepairTheShip(pirateShip, givenCommand, maxHealth);
                }
                else if (currCommand == "Status")
                {
                    PrintCurrStatus(pirateShip, maxHealth);
                }
                command = Console.ReadLine();
            }
            PrintResult(pirateShip, warship);
        }
        public static bool IsWarshipIndexValid(int index, List<int> warship)
        {
            if (index >= 0 && index < warship.Count)
            {
                return true;
            }
            return false;
        }
        public static bool IsPirateShipIndexValid(int startIdnex, int endIndex, List<int> pirateShip)
        {
            if (startIdnex >= 0 && startIdnex < pirateShip.Count && endIndex >= 0 && endIndex < pirateShip.Count)
            {
                return true;
            }
            return false;
        }
        public static bool IsPirateShipRepairIndexValid(int index, List<int> pirateShip)
        {
            if (index >= 0 && index < pirateShip.Count)
            {
                return true;
            }
            return false;
        }
        public static void AttackTheWarship(string[] givenCommand, List<int> warship)
        {
            int index = int.Parse(givenCommand[1]);
            int damage = int.Parse(givenCommand[2]);
            if (IsWarshipIndexValid(index, warship))
            {
                warship[index] -= damage;
                if (warship[index] <= 0)
                {
                    Console.WriteLine("You won! The enemy ship has sunken.");
                    Environment.Exit(0);
                }
            }
        }
        public static void SubstractionPirateShip(List<int> pirateShip, string[] givenCommand)
        {
            int startIndex = int.Parse(givenCommand[1]);
            int endIndex = int.Parse(givenCommand[2]);
            int damage = int.Parse(givenCommand[3]);
            if (IsPirateShipIndexValid(startIndex, endIndex, pirateShip))
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    pirateShip[i] -= damage;
                    if (pirateShip[i] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static void RepairTheShip(List<int> pirateShip, string[] givenCommand, int maxHealth)
        {
            int index = int.Parse(givenCommand[1]);
            int health = int.Parse(givenCommand[2]);
            if (IsPirateShipRepairIndexValid(index, pirateShip))
            {
                pirateShip[index] += health;
                if (pirateShip[index] > maxHealth)
                {
                    pirateShip[index] = maxHealth;
                }
            }
        }
        public static void PrintCurrStatus(List<int> pirateShip, int maxHealth)
        {
            int count = 0;
            foreach (var item in pirateShip)
            {
                if (item < maxHealth * 0.2)
                {
                    count++;
                }
            }
            Console.WriteLine($"{count} sections need repair.");
        }
        public static void PrintResult(List<int> pirateShip, List<int> warship)
        {
            if (pirateShip.Count > 0 && warship.Count > 0)
            {
                Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                Console.WriteLine($"Warship status: {warship.Sum()}");
            }
        }
    }
}
