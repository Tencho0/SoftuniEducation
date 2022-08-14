namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
                return string.Format(OutputMessages.ExistingPlanet, name);

            Planet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));


            IMilitaryUnit militaryUnit = null;
            if (unitTypeName == nameof(AnonymousImpactUnit))
                militaryUnit = new AnonymousImpactUnit();
            else if (unitTypeName == nameof(SpaceForces))
                militaryUnit = new SpaceForces();
            else if (unitTypeName == nameof(StormTroopers))
                militaryUnit = new StormTroopers();
            else
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));

            IWeapon weapon = null;
            if (weaponTypeName == nameof(BioChemicalWeapon))
                weapon = new BioChemicalWeapon(destructionLevel);
            else if (weaponTypeName == nameof(NuclearWeapon))
                weapon = new NuclearWeapon(destructionLevel);
            else if (weaponTypeName == nameof(SpaceMissiles))
                weapon = new SpaceMissiles(destructionLevel);
            else
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var currentPlanet = planets.FindByName(planetName);

            if (currentPlanet == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            if (!currentPlanet.Army.Any())
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);

            currentPlanet.Spend(1.25);
            currentPlanet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planetAttacker = planets.FindByName(planetOne);
            var planetToAttack = planets.FindByName(planetTwo);

            bool attackerHasNuclearWeapon = planetAttacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderHasNuclearWeapon = planetToAttack.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner;
            IPlanet lost;
            if (planetAttacker.MilitaryPower > planetToAttack.MilitaryPower)
            {
                winner = planetAttacker;
                lost = planetToAttack;
            }
            else if (planetToAttack.MilitaryPower > planetAttacker.MilitaryPower)
            {
                winner = planetToAttack;
                lost = planetAttacker;
            }
            else
            {
                if (attackerHasNuclearWeapon && !defenderHasNuclearWeapon)
                {
                    winner = planetAttacker;
                    lost = planetToAttack;
                }
                else if (defenderHasNuclearWeapon && !attackerHasNuclearWeapon)
                {
                    winner = planetToAttack;
                    lost = planetAttacker;
                }
                else
                {
                    planetAttacker.Spend(planetAttacker.Budget / 2);
                    planetToAttack.Spend(planetToAttack.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }
            winner.Spend(winner.Budget / 2);
            winner.Profit(lost.Budget / 2);
            winner.Profit(lost.Army.Sum(u => u.Cost) + lost.Weapons.Sum(w => w.Price));
            planets.RemoveItem(lost.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, lost.Name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
