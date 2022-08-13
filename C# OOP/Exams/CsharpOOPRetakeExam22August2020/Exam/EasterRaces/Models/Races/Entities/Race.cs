namespace EasterRaces.Models.Races.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            drivers = new List<IDriver>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);

            if (!driver.CanParticipate)
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));

            if (this.Drivers.Any(x => x == driver))
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriversExists, driver.Name, this.Name));

            this.drivers.Add(driver);
        }
    }
}
