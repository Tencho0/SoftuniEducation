using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TestPlanetConstructor()
            {
                Planet planet = new Planet("iME", 24);
                Assert.AreEqual("iME", planet.Name);
                Assert.AreEqual(24, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void PlanetNameProp_ShouldThrowException_InvalidData()
            {
                Planet planet;
                Assert.Throws<ArgumentException>(() => planet = new Planet(null, 242), "Invalid planet Name");
                Assert.Throws<ArgumentException>(() => planet = new Planet("", 242), "Invalid planet Name");
            }
            [Test]
            public void PlanetBudgetProp_ShouldThrowException_InvalidData()
            {
                Planet planet;
                Assert.Throws<ArgumentException>(() => planet = new Planet("Planeta", -2), "Budget cannot drop below Zero!");
            }
            [Test]
            public void ProfitMethod_ShouldIncreaseBudget_ValidData()
            {
                Planet planet = new Planet("Kometa", 200);
                planet.Profit(2000);
                Assert.AreEqual(2200, planet.Budget);
            }
            [Test]
            public void AddWeaponMethod_ShouldAddWeapon_ValidData()
            {
                Planet planet = new Planet("Kometa", 2222200);
                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.Weapons.Count);
            }
            [Test]
            public void AddWeaponMethod_ShouldThrowException_InvalidData()
            {
                Planet planet = new Planet("Kometa", 20222220);
                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon2), $"There is already a {weapon2.Name} weapon.");
            }
            [Test]
            public void MilitaryPowerRatio_ShouldReturnRatio_ValidData()
            {
                Planet planet = new Planet("Kometa", 20222220);
                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(20, planet.MilitaryPowerRatio);
            }
            [Test]
            public void SpendFunds_ShouldDecreaseBudget_ValidData()
            {
                Planet planet = new Planet("Kometa", 2000);

                planet.SpendFunds(200);

                Assert.AreEqual(1800, planet.Budget);
            }
            [Test]
            public void SpendFunds_ShouldThrowException_InvalidData()
            {
                Planet planet = new Planet("Kometa", 2000);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(2200), "Not enough funds to finalize the deal.");
            }
            [Test]
            public void RemoveWeapon_ShouldRemoveFromCollection_ValidData()
            {
                Planet planet = new Planet("Kometa", 2000);
                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon(weapon2.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWeaponWeapon_ShouldUpgeade_ValidData()
            {
                Planet planet = new Planet("Kometa", 2000);
                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.UpgradeWeapon(weapon2.Name);

                Assert.AreEqual(13, weapon2.DestructionLevel);
            }
            [Test]
            public void UpgradeWeaponWeapon_ShouldThrowException_InvalidData()
            {
                Planet planet = new Planet("Kometa", 2000);
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("gotino orujie"), $"gotino orujie does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void DestructOpponent_ShouldThrowException_InvalidData()
            {
                Planet planet = new Planet("Kometa", 2000);
                Planet enemyPlanet = new Planet("Asteroid", 3000);

                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);
                Weapon weapon3 = new Weapon("Malka bombichka", 20, 1);
                Weapon weapon4 = new Weapon("Shumna bomba", 200, 3);

                planet.AddWeapon(weapon3);
                planet.AddWeapon(weapon4);
                enemyPlanet.AddWeapon(weapon);
                enemyPlanet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(enemyPlanet), $"{enemyPlanet.Name} is too strong to declare war to!");
            }
            [Test]
            public void DestructOpponent_ShouldDestructEnemy_ValidData()
            {
                Planet planet = new Planet("Kometa", 2000);
                Planet enemyPlanet = new Planet("Asteroid", 3000);

                Weapon weapon = new Weapon("BOMBA", 2000, 8);
                Weapon weapon2 = new Weapon("Golqma bomba", 22000, 12);
                Weapon weapon3 = new Weapon("Malka bombichka", 20, 1);
                Weapon weapon4 = new Weapon("Shumna bomba", 200, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                enemyPlanet.AddWeapon(weapon3);
                enemyPlanet.AddWeapon(weapon4);
                var result = planet.DestructOpponent(enemyPlanet);
                var expectedResult = $"{enemyPlanet.Name} is destructed!";

                Assert.AreEqual(expectedResult, result);
            }
            [Test]
            public void TestWeapon()
            {
                Weapon weapon = new Weapon("orujie", 200, 2);
                Assert.AreEqual("orujie", weapon.Name);
                Assert.AreEqual(200, weapon.Price);
                Assert.AreEqual(2, weapon.DestructionLevel);
            }
            [Test]
            public void Weapon_ShouldThrowException_invalidPrice()
            {
                Weapon weapon;
                Assert.Throws<ArgumentException>(() => weapon = new Weapon("orujie", -2, 4), "Price cannot be negative.");
            }
            [Test]
            public void IsNuclearMethod()
            {
                Weapon weapon = new Weapon("orujie", 200, 2);
                Assert.True(!weapon.IsNuclear);
            }
        }
    }
}
