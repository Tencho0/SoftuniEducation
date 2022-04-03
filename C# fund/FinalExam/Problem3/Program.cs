using System;
using System.Collections.Generic;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string heroName = givenCmd[1];
                if (action == "Enroll")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        Hero hero = new Hero();
                        heroes[heroName] = hero;
                    }
                }
                else if (action == "Learn")
                {
                    string spellName = givenCmd[2];
                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (heroes[heroName].SpellBook.Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                        else
                        {
                            heroes[heroName].SpellBook.Add(spellName);
                        }
                    }
                }
                else if (action == "Unlearn")
                {
                    string spellName = givenCmd[2];
                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (!heroes[heroName].SpellBook.Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                        else
                        {
                            heroes[heroName].SpellBook.Remove(spellName);
                        }
                    }
                }
                command = Console.ReadLine();
            }
                Console.WriteLine($"Heroes:");
            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value.SpellBook)}");
            }
        }
    }
    class Hero
    {
        public Hero()
        {
            SpellBook = new List<string>();
        }
        public List<string> SpellBook { get; set; }
    }
}
