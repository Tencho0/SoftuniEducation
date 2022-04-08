using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        private int age;
        private double pressure;
        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
