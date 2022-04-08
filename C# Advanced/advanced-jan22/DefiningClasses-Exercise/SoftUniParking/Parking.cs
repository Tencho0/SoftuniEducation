using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            Cars = new Dictionary<string, Car>();
            this.Capacity = capacity;
        }
        public Dictionary<string, Car> Cars
        {
            get
            {
                return cars;
            }
            set
            {
                cars = value;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        public int Count { get { return cars.Count; } }
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return ($"Car with that registration number, already exists!");
            }
            if (cars.Count >= capacity)
            {
                return ($"Parking is full!");
            }
            Cars.Add(car.RegistrationNumber, car);
            return ($"Successfully added new car {car.Make} {car.RegistrationNumber}");
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (!cars.ContainsKey(RegistrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            Cars.Remove(RegistrationNumber);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string RegistrationNumber)
        {
            return cars[RegistrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string RegistrationNumber in RegistrationNumbers)
            {
                if (cars.ContainsKey(RegistrationNumber))
                {
                    cars.Remove(RegistrationNumber);
                }
            }
        }
    }
}
