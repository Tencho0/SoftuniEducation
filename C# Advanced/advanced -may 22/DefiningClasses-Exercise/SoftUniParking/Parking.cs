namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new Dictionary<string, Car>();
        }
        public int Count { get => cars.Count; }
        public Dictionary<string, Car> Cars
        {
            get { return cars; }
            private set { cars = value; }
        }

        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
                return $"Car with that registration number, already exists!";
            if (Cars.Count + 1 > capacity)
                return $"Parking is full!";

            Cars[car.RegistrationNumber] = car;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.ContainsKey(registrationNumber))
            {
                Cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
            return $"Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber) => Cars[registrationNumber];
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
            => registrationNumbers.ForEach(x => Cars.Remove(x));
    }
}
