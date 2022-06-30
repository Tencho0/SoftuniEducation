namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_Should_Initialize_Data()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        public void Enroll_Should_Add_Warriors_Valid_Data()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("qnko", 100, 100);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
            Assert.True(arena.Warriors.Any(x => x.Name == "qnko"));
        }
        [Test]
        public void Enroll_Should_ThrowException_Invalid_Data()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("qnko", 100, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
        }
        [Test]
        public void Fight_Should_Reduce_HP_ValidData()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("qnko", 101, 100);
            Warrior deffender = new Warrior("dqnko", 60, 100);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight("qnko", "dqnko");

            Assert.AreEqual(0,
                deffender.HP);
            Assert.AreEqual(40,
                attacker.HP);
        }
        [Test]
        public void Fight_Should_Throw_Exception_When_Warrior_Doesnt_Exist()
        {
            Arena arena = new Arena();
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Stoyan", "Kiro"));

            arena.Enroll(new Warrior("Stoyan", 100, 100));
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Stoyan", "Kiro"));
        }
    }
}
