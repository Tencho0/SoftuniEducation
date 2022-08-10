﻿namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);

                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }
    }
}
