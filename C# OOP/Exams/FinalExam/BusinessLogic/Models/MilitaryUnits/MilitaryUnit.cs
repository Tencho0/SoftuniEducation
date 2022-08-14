namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost
        {
            get => cost;
            private set
            {
                this.cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                if (value > 20)
                {
                    value = 20;
                    this.enduranceLevel = value;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
        }
    }
}
