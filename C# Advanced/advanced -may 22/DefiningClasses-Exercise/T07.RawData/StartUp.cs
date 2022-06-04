namespace T07.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static List<Car> cars;
        static void Main(string[] args)
        {
            cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateNewCar(givenCmd);
                cars.Add(car);
            }

            string commands = Console.ReadLine();
            FilterCars(commands);
            cars.ForEach(x => Console.WriteLine(x.Model));
        }

        private static void FilterCars(string commands)
        {
            if (commands == "fragile")
                cars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1)).ToList();
            else if (commands == "flammable")
                cars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
        }

        private static Car CreateNewCar(string[] givenCmd)
        {
            string model = givenCmd[0];
            int engineSpeed = int.Parse(givenCmd[1]);
            int enginePower = int.Parse(givenCmd[2]);
            int cargoWeight = int.Parse(givenCmd[3]);
            string cargoType = givenCmd[4];
            double tire1Pressure = double.Parse(givenCmd[5]);
            int tire1Age = int.Parse(givenCmd[6]);
            double tire2Pressure = double.Parse(givenCmd[7]);
            int tire2Age = int.Parse(givenCmd[8]);
            double tire3Pressure = double.Parse(givenCmd[9]);
            int tire3Age = int.Parse(givenCmd[10]);
            double tire4Pressure = double.Parse(givenCmd[11]);
            int tire4Age = int.Parse(givenCmd[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoType, cargoWeight);
            Tire[] tires = new Tire[]
            {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
            };

            Car car = new Car(model, engine, cargo, tires);

            return car;
        }
    }
}
