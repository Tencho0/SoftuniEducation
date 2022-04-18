using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsepower ,double fuel)
            : base(horsepower, fuel)
        {

        }
        //public const double DefaultFuelConsumption = 10;
        public override double FuelConsumption => 10;
    }
}
