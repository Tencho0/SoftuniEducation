using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CreateShop_TestConstructor_ValidData()
        {
            Shop shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void CreateShop_InvalidData()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-2), "Invalid capacity.");
        }
        [Test]
        public void AddMethod_ShouldAddPhone_ValidData()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Samsung", 3000);
            Smartphone smartphone2 = new Smartphone("Huawei", 3000);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            Assert.AreEqual(2, shop.Count);
        }
        [Test]
        public void AddMethod_ShouldThrowException_InvalidData()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Samsung", 3000);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone), $"The phone model {smartphone.ModelName} already exist.");
        }
        [Test]
        public void AddMethod_ShouldThrowException__NotEnoughtCapacity_InvalidData()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Samsung", 3000);
            Smartphone smartphone2 = new Smartphone("Samsung", 5000);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone2), "The shop is full.");
        }
        [Test]
        public void RemoveMethod_ShouldThrowException__InvalidData()
        {
            Shop shop = new Shop(1);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("IPhone"), "The phone model IPhone doesn't exist.");
        }
        [Test]
        public void RemoveMethod_ShouldRemovePhone_ValidData()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Samsung", 3000);
            Smartphone smartphone2 = new Smartphone("Huawei", 3000);
            Smartphone smartphone3 = new Smartphone("IPhone", 3000);
            Smartphone smartphone4 = new Smartphone("Xiomi", 3000);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.Add(smartphone3);
            shop.Add(smartphone4);
            shop.Remove(smartphone.ModelName);
            shop.Remove(smartphone4.ModelName);

            Assert.AreEqual(2, shop.Count);
        }
        [Test]
        public void TestPhoneMethod_ShouldDecresePhoneBatery_ValidData()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Samsung", 3000);
            Smartphone smartphone2 = new Smartphone("Huawei", 3000);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.TestPhone(smartphone.ModelName, 200);
            shop.TestPhone(smartphone2.ModelName, 500);

            Assert.AreEqual(2800, smartphone.CurrentBateryCharge);
            Assert.AreEqual(2500, smartphone2.CurrentBateryCharge);
        }
        [Test]
        public void TestPhoneMethod_ShouldThrowException_InvalidPhoneName()
        {
            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("mi 20", 200), "The phone model mi 20 doesn't exist.");
        }
        [Test]
        public void TestPhoneMethod_ShouldThrowException__NotEnoughtBateryCapacity_InvalidData()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Samsung", 3000);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, 3001), $"The phone model {smartphone.ModelName} is low on batery.");
        }
        [Test]
        public void ChargePhoneMethod_ShouldIncresePhoneBatery_ValidData()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Samsung", 3000);
            Smartphone smartphone2 = new Smartphone("Huawei", 3000);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.TestPhone(smartphone.ModelName, 200);
            shop.TestPhone(smartphone2.ModelName, 500);
            shop.ChargePhone(smartphone.ModelName);
            shop.ChargePhone(smartphone2.ModelName);

            Assert.AreEqual(3000, smartphone.CurrentBateryCharge);
            Assert.AreEqual(3000, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void ChargePhoneMethod_ShouldThrowException_InvalidPhoneName()
        {
            Shop shop = new Shop(5);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("mi 20"), "The phone model mi 20 doesn't exist.");
        }
    }
}