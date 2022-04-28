using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBaseHero> heroes = new List<IBaseHero>();

            int n = int.Parse(Console.ReadLine());
            while (heroes.Count != n)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    IBaseHero hero = HeroFactory.CreateHero(heroType, heroName);
                    if (hero != null)
                    {
                        heroes.Add(hero);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            long bossPower = long.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            long allPower = heroes.Select(x => x.Power).Sum();
            if (allPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

            //long bossPower = long.Parse(Console.ReadLine());
            // heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            // int totalPower = heroes.Sum(x => x.Power);
            // //long totalPower = 0;
            // //foreach (var hero in heroes)
            // //{
            // //    Console.WriteLine(hero.CastAbility());
            // //    totalPower += hero.Power;
            // //}
            // if (totalPower >= bossPower)
            // {
            //     Console.WriteLine($"Victory!");
            // }
            // else
            // {
            //     Console.WriteLine($"Defeat...");
            // }
        }
    }
}
