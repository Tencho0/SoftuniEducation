namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        private decimal militaryPower;

        public Planet(string name, double budget)
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                return this.CalculateMilitaryPower();
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: " + (this.units.Models.Count == 0 ? "No units" : string.Join(", ", this.units.Models.Select(x=> x.GetType().Name))));
            sb.AppendLine($"--Combat equipment: " + (this.weapons.Models.Count == 0 ? "No weapons" : string.Join(", ", this.weapons.Models.Select(x => x.GetType().Name))));
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget - amount < 0)
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = (this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel));

            if (this.units.FindByName(nameof(MilitaryUnit)) != null)
                totalAmount *= 1.3;

            if (this.weapons.FindByName(nameof(NuclearWeapon)) != null)
                totalAmount *= 1.45;

            return Math.Round(totalAmount, 3);
        }
    }
}
