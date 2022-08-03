namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCaseSource("ConstructorInvalidCases")]
        public void Constructor_ShouldThrowException_InvalidData(string make, string model, double consume, double capacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, consume, capacity), "Passing in invalid arguments should throw their respective messages.");
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void RefuelMethod_ShouldThrowException_InvalidData(double amount)
        {
            Car car = new Car("BMW", "E60", 4.0, 30);
            Assert.Throws<ArgumentException>(() => car.Refuel(amount), "Refueling with a number lower or equal to zero should not be possible and should throw argument exception.");
        }

        [TestCase(15)]
        [TestCase(29.99)]
        public void RefuelCarMethod_ShouldRefuel_ValidData(double amount)
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            car.Refuel(amount);

            Assert.AreEqual(amount, car.FuelAmount, "Refueling should increase cars' fuel capacity correctly.");
        }

        [Test]
        public void RefuelCarMethod_WithMoreLitersThanMax_ShouldBeSetToMax()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            car.Refuel(50);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount, "Refueling above the cars' max fuel capacity should set the fuel amount to the cars' max fuel capacity.");
        }

        [Test]
        public void DriveCarMethod_ShouldThrowException_InvalidData()
        {
            Car car = new Car("BMW", "E46", 10, 30);

            Assert.Throws<InvalidOperationException>(() => car.Drive(310), "Driving a car X amount of kilometers without enough fuel whould throw an invalid operation exception");
        }

        [Test]
        public void DriveCarMethod_ShouldSubtractFromTotalFuel_ValidData()
        {
            Car car = new Car("BMW", "E60", 10, 30);

            car.Refuel(30);
            car.Drive(290);

            Assert.AreEqual(1, car.FuelAmount, "Driving a car X amount of kilometers with enough fuel should subtract that fuel from the total fuel.");
        }

        [Test]
        public void MakeGetter_ShouldReturnCorrectField()
        {
            Car car = new Car("BMW", "E90", 4.0, 30);

            Assert.AreEqual("BMW", car.Make, "Make should return correct field");
        }

        [Test]
        public void ModelGetter_ShouldReturnCorrectField()
        {
            Car car = new Car("BMW", "E60", 4.0, 30);

            Assert.AreEqual("E60", car.Model, "Model should return correct field");
        }

        [Test]
        public void ConsumeGetter_ShouldReturnCorrectField()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            Assert.AreEqual(4, car.FuelConsumption, "Fuel consumption should return correct field");
        }

        [Test]
        public void CapacityGetter_ShouldReturnCorrectField()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            Assert.AreEqual(30, car.FuelCapacity, "Fuel capacity should return correct field");
        }

        [Test]
        public void AmountGetter_ShouldReturnCorrectField()
        {
            Car car = new Car("Ferrari", "812 GTS", 4.0, 30);

            Assert.AreEqual(0, car.FuelAmount, "Fuel amount should return correct field");
        }

        public static IEnumerable<TestCaseData> ConstructorInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData("", "Model S", 20, 300),
                new TestCaseData(null, "812 GTS", 100.35, 500.12),
                new TestCaseData("Tesla", "", 20, 300),
                new TestCaseData("Ferrari", null, 100, 500),
                new TestCaseData("Tesla", "Model S", 0, 300),
                new TestCaseData("Ferrari", "812 GTS", -20, 500.57),
                new TestCaseData("Tesla", "Model S", 321, -800),
                new TestCaseData("Ferrari", "812 GTS", 4.0, 0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }
    }
}