using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void TestGarageConstructor()
            {
                Garage garage = new Garage("Golqm garaj", 2);
                Assert.AreEqual("Golqm garaj", garage.Name);
                Assert.AreEqual(2, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [Test]
            public void Name_ShouldThrowException_InvalidData()
            {
                Garage garage;
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(null, 2), "Invalid garage name.");
                Assert.Throws<ArgumentNullException>(() => garage = new Garage("", 2), "Invalid garage name.");
            }
            [Test]
            public void MechanicsProp_ShouldThrowException_InvalidData()
            {
                Garage garage;
                Assert.Throws<ArgumentException>(() => garage = new Garage("Golqm garaj", 0), "At least one mechanic must work in the garage.");
                Assert.Throws<ArgumentException>(() => garage = new Garage("Maluk garaj", -1), "At least one mechanic must work in the garage.");
            }
            [Test]
            public void AddCarMethod_ShouldAddCar_ValidData()
            {
                Garage garage = new Garage("Golqm garaj", 5);
                Car car = new Car("BMW", 2);
                Car car2 = new Car("Audi", 324);
                Car car3 = new Car("Mechok", 1);

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);

                Assert.AreEqual(3, garage.CarsInGarage);
            }
            [Test]
            public void AddCarMethod_ShouldThrowException_InvalidData()
            {
                Garage garage = new Garage("Golqm garaj", 2);
                Car car = new Car("BMW", 2);
                Car car2 = new Car("Audi", 324);
                Car car3 = new Car("Mechok", 1);

                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car3), "No mechanic available.");
            }
            [Test]
            public void FixCarMethod_ShouldThrowException_InvalidData()
            {
                Garage garage = new Garage("Golqm garaj", 2);
                Car car = new Car("BMW", 2);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Audi"), "The car Audi doesn't exist.");
            }
            [Test]
            public void FixCarMethod_ShouldRepairCar_ValidData()
            {
                Garage garage = new Garage("Golqm garaj", 2);
                Car car = new Car("BMW", 2);

                garage.AddCar(car);
                Car repairedCar = garage.FixCar(car.CarModel);

                Assert.AreEqual(0, repairedCar.NumberOfIssues);
                Assert.True(repairedCar.IsFixed);
                Assert.AreSame(car, repairedCar);
            }
            [Test]
            public void RemoveFixedCarsMethod_ShouldRemoveFixedCars_ValidData()
            {
                Garage garage = new Garage("Golqm garaj", 5);
                Car car = new Car("BMW", 2);
                Car car2 = new Car("Golf", 5);
                Car car3 = new Car("Bri4ka", 7);
                Car car4 = new Car("Karuca", 0);
                Car car5 = new Car("Burza korsa", 12);

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.AddCar(car4);
                garage.AddCar(car5);

                garage.FixCar(car.CarModel);
                garage.FixCar(car2.CarModel);
                garage.FixCar(car3.CarModel);

                int repairedCars = garage.RemoveFixedCar();

                Assert.AreEqual(4, repairedCars);
                Assert.AreEqual(1, garage.CarsInGarage);
            }
            [Test]
            public void RemoveFixedCarsMethod_ShouldThrowException_InvalidData()
            {
                Garage garage = new Garage("Golqm garaj", 5);
                Car car = new Car("BMW", 2);
                Car car2 = new Car("Golf", 5);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }
            [Test]
            public void ReportMethod_ShouldReturnString()
            {
                Garage garage = new Garage("Golqm garaj", 10);
                Car car = new Car("BMW", 2);
                Car car2 = new Car("Golf", 5);
                Car car3 = new Car("A3", 14);
                Car car4 = new Car("Q7", 10);
                Car car5 = new Car("Mechoka", 3);
                Car car6 = new Car("Ladata", 7);
                var cars = new List<Car>()
                {
                    car, car2, car3, car4
                };

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.AddCar(car4);
                garage.AddCar(car5);
                garage.AddCar(car6);
                garage.FixCar(car5.CarModel);
                garage.FixCar(car6.CarModel);

                string carsModels = string.Join(", ", cars.Select(x => x.CarModel));
                string expectedReport = $"There are {cars.Count} which are not fixed: {carsModels}.";
                string report = garage.Report();

                Assert.AreEqual(expectedReport, report);
            }

        }
    }
}