using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "e60";
            car.Year = 2007;
            Console.WriteLine($"Make: {car.Make} \nModel: {car.Make} \nYear: {car.Year}");
        }
    }
}
