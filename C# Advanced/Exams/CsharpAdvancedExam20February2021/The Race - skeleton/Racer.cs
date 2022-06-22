using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        private string name;
        private int age;
        private string country;
        private Car car;

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        public override string ToString()
        {
            return $"Racer: {name}, {age} ({country})";
        }
    }
}
