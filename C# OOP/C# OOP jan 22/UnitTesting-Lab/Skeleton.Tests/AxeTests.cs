using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Attack_Looses_Durability()
        {
            Axe axe = new Axe(10, 20);
            axe.Attack(new Dummy(100, 100));
            Assert.AreEqual(19, axe.DurabilityPoints);
        }

        [Test]
        public void Test_Attack_With_Zero_Durability_Throws_Error()
        {
            Axe axe = new Axe(10, 1);
            axe.Attack(new Dummy(100, 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });
        }

        [Test]
        public void Test_Attack_With_Negative_Durability_Throws_Error()
        {
            Axe axe = new Axe(10, -1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });
        }
    }
}