namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destuctionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price
        {
            get => price;
            private set { price = value; }
        }

        public int DestructionLevel
        {
            get => destuctionLevel;
            private set
            {
                if (value < 1)
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);

                if (value > 10)
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);

                this.destuctionLevel = value;
            }
        }
    }
}
