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
                string[] givenInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = givenInput[0];
                int health = int.Parse(givenInput[1]);
                int mana = int.Parse(givenInput[2]);
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
                string hero = givenCmd[1];
                if (action == "CastSpell")
                {
                    int mana = int.Parse(givenCmd[2]);
                    string spell = givenCmd[3];
                    if (heroes[hero].Mana - mana <0)
                    {
                        Console.WriteLine($"{hero} does not have enough MP to cast {spell}!");
                    }
                    else
                    {
                        heroes[hero].Mana -= mana;
                        Console.WriteLine($"{hero} has successfully cast {spell} and now has {heroes[hero].Mana} MP!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(givenCmd[2]);
                    string attacker = givenCmd[3];
                    heroes[hero].Health -= damage;
                    if (heroes[hero].Health <= 0)
                    {
                        heroes.Remove(hero);
                        Console.WriteLine($"{hero} has been killed by {attacker}!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {heroes[hero].Health} HP left!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(givenCmd[2]);
                    int added = amount;
                    if (heroes[hero].Mana + amount > 200)
                    {
                        added = 200 - heroes[hero].Mana;
                    }
                    heroes[hero].Mana += added;
                    Console.WriteLine($"{hero} recharged for {added} MP!");
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(givenCmd[2]);
                    int added = amount;
                    if (heroes[hero].Health + amount > 100)
                    {
                        added = 100 - heroes[hero].Health;
                    }
                    heroes[hero].Health += added;
                    Console.WriteLine($"{hero} healed for {added} HP!");
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
