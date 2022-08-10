namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            this.Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items => items;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);

                name = value;
            }
        }
    }
}
