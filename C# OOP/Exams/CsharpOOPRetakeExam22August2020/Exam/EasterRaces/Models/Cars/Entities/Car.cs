namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));

                horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => cubicCentimeters;
            private set
            {
                cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
            => cubicCentimeters / horsePower * laps;
    }
}
