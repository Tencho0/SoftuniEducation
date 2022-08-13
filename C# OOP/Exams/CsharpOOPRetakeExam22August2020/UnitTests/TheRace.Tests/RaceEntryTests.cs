using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void TestConstuctor()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }
        [Test]
        public void AddDriverMethod_ShouldAddDrive_ValidData()
        {
            var result = raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("BMW", 231, 3000)));
            var expectedResult = "Driver Misho added in race.";
            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void AddDriverMethod_ShouldThrowInvalidOperationException_DriverIsNull_InvalidData()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null), "Driver cannot be null.");
        }
        [Test]
        public void AddDriverMethod_ShouldThrowInvalidOperationException_DriverAlreadyExists_InvalidData()
        {
            var result = raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("BMW", 231, 3000)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("BMW", 231, 3000))), "Driver Misho is already added.");
        }
        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldThrowInvalidOperationException_InvalidData()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than {0} participants.");
        }
        [Test]
        public void CalculateAverageHorsePowerMethod_ShouldCalculate_ValidData()
        {
            raceEntry.AddDriver(new UnitDriver("Misho", new UnitCar("BMW", 218, 3000)));
            raceEntry.AddDriver(new UnitDriver("Pesho", new UnitCar("Audi", 90, 1900)));
            Assert.AreEqual(154, raceEntry.CalculateAverageHorsePower());
        }
    }
}