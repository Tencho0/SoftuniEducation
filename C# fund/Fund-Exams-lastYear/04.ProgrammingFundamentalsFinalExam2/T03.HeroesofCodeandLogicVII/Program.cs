using System;
using System.Collections.Generic;

namespace T03.HeroesofCodeandLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int health = int.Parse(input[1]);
                int mana = int.Parse(input[2]);
                Hero hero = new Hero()
                {
                    Health = health,
                    Mana = mana
                };
                heroes[name] = hero;
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = givenCmd[0];
                string name = givenCmd[1];

                if (action == "CastSpell")
                {
                    int mana = int.Parse(givenCmd[2]);
                    string spellName = givenCmd[3];
                    if (heroes[name].Mana >= mana)
                    {
                        heroes[name].Mana -= mana;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(givenCmd[2]);
                    string attacker = givenCmd[3];
                    heroes[name].Health -= damage;
                    if (heroes[name].Health > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].Health} HP left!");
                    }
                    else
                    {
                        heroes.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    int oldMana = heroes[name].Mana;
                    int newMana = int.Parse(givenCmd[2]);
                    int addedMana = newMana;
                    if (oldMana + newMana > 200)
                    {
                        addedMana = 200 - oldMana;
                    }
                    heroes[name].Mana += addedMana;
                    Console.WriteLine($"{name} recharged for {addedMana} MP!");
                }
                else if (action == "Heal")
                {
                    int oldHealth = heroes[name].Health;
                    int newHealth = int.Parse(givenCmd[2]);
                    int addedHealth = newHealth;
                    if (oldHealth + newHealth > 100)
                    {
                        addedHealth = 100 - oldHealth;
                    }
                    heroes[name].Health += addedHealth;
                    Console.WriteLine($"{name} healed for {addedHealth} HP!");
                }
                command = Console.ReadLine();
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.Health}");
                Console.WriteLine($"  MP: {hero.Value.Mana}");
            }
        }
    }
    class Hero
    {
        public int Health { get; set; }
        public int Mana { get; set; }
    }
}
