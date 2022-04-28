
using System;

namespace Raiding
{
    public static class HeroFactory
    {
        public static IBaseHero CreateHero(string heroType, string heroName)
        {
            IBaseHero hero = null;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
