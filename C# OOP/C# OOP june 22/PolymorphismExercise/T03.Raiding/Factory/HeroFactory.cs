namespace T03.Raiding.Factory
{
    using System;
    using Model;
    public class HeroFactory
    {
        public static BaseHero CreateHero(string heroName, string heroType)
        {
            if (heroType == "Druid")
                return new Druid(heroName);

            if (heroType == "Paladin")
                return new Paladin(heroName);

            if (heroType == "Rogue")
                return new Rogue(heroName);

            if (heroType == "Warrior")
                return new Warrior(heroName);

            throw new InvalidOperationException($"Invalid hero!");
        }
    }
}
