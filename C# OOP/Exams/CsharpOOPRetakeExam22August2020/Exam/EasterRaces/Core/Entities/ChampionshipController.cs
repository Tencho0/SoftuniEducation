namespace EasterRaces.Core.Entities
{
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = this.cars.GetByName(carModel);
            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriversExists, driverName));

            if (car == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExists, carModel));

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetByName(raceName);
            var driver = this.drivers.GetByName(driverName);

            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            if (driver == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));

            ICar car = null;
            if (type == "Muscle")
                car = new MuscleCar(model, horsePower);
            else if (type == "Sports")
                car = new SportsCar(model, horsePower);

            this.cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));

            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));

            IRace race = new Race(name, laps);
            this.races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            if (race.Drivers.Count < 3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));

            var winners = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(1)).Take(3).ToArray();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
