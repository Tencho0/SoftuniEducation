namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.FindByName(weaponName);
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");

            if (weapon == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            weapons.Remove(weapon);
            hero.AddWeapon(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
                throw new InvalidOperationException($"The hero {name} already exists.");

            string result = string.Empty;
            IHero hero;
            if (type == typeof(Knight).Name)
            {
                hero = new Knight(name, health, armour);
                result = $"Successfully added Sir { name } to the collection.";
            }
            else if (type == typeof(Barbarian).Name)
            {
                hero = new Barbarian(name, health, armour);
                result = $"Successfully added Barbarian { name } to the collection.";
            }
            else
                throw new InvalidOperationException("Invalid hero type.");

            heroes.Add(hero);
            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            IWeapon weapon;
            if (type == typeof(Mace).Name)
                weapon = new Mace(name, durability);
            else if (type == typeof(Claymore).Name)
                weapon = new Claymore(name, durability);
            else
                throw new InvalidOperationException("Invalid weapon type.");

            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == null)
                    sb.AppendLine("--Weapon: Unarmed");
                else
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            return map.Fight(heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList());
        }
    }
}
