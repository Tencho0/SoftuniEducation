namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        [Test]
        public void TestAquariumConstructor()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 200);
            Assert.AreEqual("Golqm akwarium", aquarium.Name);
            Assert.AreEqual(200, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void TestNamePropValidation_ShouldThrowException_InvalidData()
        {
            Aquarium aquarium;
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium("", 200), "Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(null, 200), "Invalid aquarium name!");
        }
        [Test]
        public void TestCapacityPropValidation_ShouldThrowException_InvalidData()
        {
            Aquarium aquarium;
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Akwarium", -1), "Invalid aquarium capacity!");
        }
        [Test]
        public void AddFishMethod_ShouldAddFish_ValidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 200);
            Fish fish = new Fish("Golqma riba");
            Fish fish2 = new Fish("Malka riba");
            Fish fish3 = new Fish("Grozna riba");
            Fish fish4 = new Fish("Wkusna riba");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            Assert.AreEqual(4, aquarium.Count);
        }
        [Test]
        public void AddFishMethod_ShouldThrowException_InvalidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 3);
            Fish fish = new Fish("Golqma riba");
            Fish fish2 = new Fish("Malka riba");
            Fish fish3 = new Fish("Grozna riba");
            Fish fish4 = new Fish("Wkusna riba");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish4), "Aquarium is full!");
        }
        [Test]
        public void RemoveFishMethod_ShouldThrowException_InvalidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 3);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Gotina riba"), "Fish with the name Gotina riba doesn't exist!");
        }
        [Test]
        public void RemoveFishMethod_ShouldRemoveFish_ValidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 200);
            Fish fish = new Fish("Golqma riba");
            Fish fish2 = new Fish("Malka riba");
            Fish fish3 = new Fish("Grozna riba");
            Fish fish4 = new Fish("Wkusna riba");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);
            aquarium.RemoveFish(fish2.Name);
            aquarium.RemoveFish(fish3.Name);

            Assert.AreEqual(2, aquarium.Count);
        }
        [Test]
        public void SellFishFishMethod_ShouldThrowException_InvalidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 3);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gotina riba"), "Fish with the name Gotina riba doesn't exist!");
        }
        [Test]
        public void SellFishMethod_ShouldDisableAndReturnFish_ValidData()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 200);
            Fish fish = new Fish("Golqma riba");
            Fish fish2 = new Fish("Malka riba");
            Fish fish3 = new Fish("Grozna riba");
            Fish fish4 = new Fish("Wkusna riba");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            Fish returnedFish = aquarium.SellFish(fish2.Name);
            Fish returnedFish2 = aquarium.SellFish(fish3.Name);

            Assert.True(!returnedFish.Available);
            Assert.True(!returnedFish2.Available);
            Assert.AreSame(fish2, returnedFish);
            Assert.AreSame(fish3, returnedFish2);
        }
        [Test]
        public void ReportMethod_ShouldReturnReportAsString()
        {
            Aquarium aquarium = new Aquarium("Golqm akwarium", 200);
            Fish fish = new Fish("Golqma riba");
            Fish fish2 = new Fish("Malka riba");
            Fish fish3 = new Fish("Grozna riba");
            Fish fish4 = new Fish("Wkusna riba");
            var givenFish = new List<Fish>()
            {
                fish, fish2, fish3, fish4
            };

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            string givenFishNames = string.Join(", ", givenFish.Select(f => f.Name));
            string expectedReport = $"Fish available at {aquarium.Name}: {givenFishNames}";
            string report = aquarium.Report();

            Assert.AreEqual(expectedReport, report);
        }
    }
}
