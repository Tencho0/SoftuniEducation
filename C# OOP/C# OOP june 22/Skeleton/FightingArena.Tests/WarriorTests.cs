namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Constructor_Should_Test_DataProterty()
        {
            Warrior warrior = new Warrior("qnko", 100, 100);
            Assert.AreEqual("qnko", warrior.Name);
            Assert.AreEqual(100, warrior.HP);
            Assert.AreEqual(100, warrior.Damage);

            warrior = new Warrior("dqnko", 1, 0);
            Assert.AreEqual("dqnko", warrior.Name);
            Assert.AreEqual(0, warrior.HP);
            Assert.AreEqual(1, warrior.Damage);
        }
        [Test]
        public void Constructor_Should_ThrowException_InvalidData()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(null, 100, 100));

            Assert.Throws<ArgumentException>(
                () => new Warrior(" ", 100, 100));

            Assert.Throws<ArgumentException>(
                () => new Warrior("", 100, 100));

            Assert.Throws<ArgumentException>(
                () => new Warrior("qnko", 0, 100));

            Assert.Throws<ArgumentException>(
                () => new Warrior("qnko", -1, 100));

            Assert.Throws<ArgumentException>(
                () => new Warrior("qnko", 50, -1));
        }
        [Test]
        public void Fight_Should_Throw_Exception_InvalidData()
        {
            Warrior attacker = new Warrior("Stoyan", 50, 5);
            Warrior deffender = new Warrior("Kiro", 50, 50);
            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));

            attacker = new Warrior("Stoyan", 50, 100);
            deffender = new Warrior("Kiro", 50, 5);
            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));

            attacker = new Warrior("Stoyan", 50, 50);
            deffender = new Warrior("Kiro", 100, 100);
            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));
        }
        [Test]
        public void Fight_Should_Fight_With_ValidData()
        {
            Warrior attacker = new Warrior("Stoyan", 101, 100);
            Warrior deffender = new Warrior("Kiro", 60, 100);

            attacker.Attack(deffender);

            Assert.AreEqual(0,
                deffender.HP);

            Assert.AreEqual(40,
                attacker.HP);


            attacker = new Warrior("Stoyan", 50, 100);
            deffender = new Warrior("Kiro", 50, 100);

            attacker.Attack(deffender);

            Assert.AreEqual(50,
                deffender.HP);

            Assert.AreEqual(50,
                attacker.HP);
        }
    }
}