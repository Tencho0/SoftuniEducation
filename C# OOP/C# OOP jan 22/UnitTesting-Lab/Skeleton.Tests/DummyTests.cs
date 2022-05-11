using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_Dummy_Looses_Health_When_Is_Attacked()
        {

            Axe axe = new Axe(10, 20);
            Dummy dummy = new Dummy(100, 100);
            axe.Attack(dummy);
            Assert.AreEqual(90, dummy.Health);
        }

        [Test]
        public void Test_Dummy_Dies_And_Throws_Exception()
        {
            Axe axe = new Axe(10, 20);
            Dummy dummy = new Dummy(5, 100);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }  
        
        [Test]
        public void Test_Dummy_Dies_And_GivesExperience()
        {
            Dummy dummy = new Dummy(-5, 100);
            int xp = dummy.GiveExperience();
            Assert.AreEqual(100, xp);
        }

        [Test]
        public void Test_Dummy_IsAlive_And_Does_Not_Give_Experience()
        {
            Dummy dummy = new Dummy(5, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                int xp = dummy.GiveExperience();
            });
        }
    }
}