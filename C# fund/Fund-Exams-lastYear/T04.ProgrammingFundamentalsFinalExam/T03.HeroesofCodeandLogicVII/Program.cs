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
                Hero hero = new Hero();
                string[] givenCmd = Console.ReadLine().Split();
                string name = givenCmd[0];
                int health = int.Parse(givenCmd[1]);
                int mana = int.Parse(givenCmd[2]);
                if (health > 100) health = 100;
                if (mana > 200) mana = 200;
                hero.Health = health;
                hero.Mana = mana;
                heroes[name] = hero;
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string name = givenCmd[1];
                if (action == "CastSpell")
                {
                    int neededMana = int.Parse(givenCmd[2]);
                    string spellName = givenCmd[3];
                    if (heroes[name].Mana >= neededMana)
                    {
                        heroes[name].Mana -= neededMana;
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
                    int amount = int.Parse(givenCmd[2]);
                    int added = amount;
                    if (heroes[name].Mana + amount > 200)
                    {
                        added = 200 - heroes[name].Mana;
                    }
                    heroes[name].Mana += added;
                    Console.WriteLine($"{name} recharged for {added} MP!");
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(givenCmd[2]);
                    int added = amount;
                    if (heroes[name].Health + amount > 100)
                    {
                        added = 100 - heroes[name].Health;
                    }
                    heroes[name].Health += added;
                    Console.WriteLine($"{name} healed for {added} HP!");
                }
                command = Console.ReadLine();
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
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
