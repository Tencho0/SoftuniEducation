namespace T03.Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using Factory;
    using Model;

    public class Engine
    {
        private List<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while(heroes.Count != n)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    BaseHero hero = HeroFactory.CreateHero(heroName, heroType);

                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            PrintResult();
        }

        private void PrintResult()
        {
            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (var currHero in heroes)
            {
                heroesPower += currHero.Power;
                Console.WriteLine(currHero.CastAbility());
            }

            if (heroesPower >= bossPower)
                Console.WriteLine($"Victory!");
            else
                Console.WriteLine($"Defeat...");
        }
    }
}
