namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 5));

                name = value;
            }
        }

        public ICar Car => car;

        public int NumberOfWins => numberOfWins;

        public bool CanParticipate => car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
                throw new ArgumentException(ExceptionMessages.CarInvalid);

            this.car = car;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
