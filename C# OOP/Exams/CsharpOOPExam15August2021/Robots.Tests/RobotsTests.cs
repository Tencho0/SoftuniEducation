namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void TestConstructor()
        {
            RobotManager manager = new RobotManager(20);
            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(20, manager.Capacity);
        }
        [Test]
        public void CapacityProp_ShouldThrowException_InvalidData()
        {
            RobotManager manager;
            Assert.Throws<ArgumentException>(() =>
            manager = new RobotManager(-2));
        }
        [Test]
        public void AddMethod_ShouldAdd_ValidData()
        {
            var manager = new RobotManager(20);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 20000);

            manager.Add(robot);
            manager.Add(robot2);

            Assert.AreEqual(2, manager.Count);
        }
        [Test]
        public void AddMethod_ShouldThrowException_RobotAlreadyExist_InvalidData()
        {
            var manager = new RobotManager(20);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);
            Robot robot3 = new Robot("jelezen robot", 10000);

            manager.Add(robot);
            manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot3), $"There is already a robot with name {robot.Name}!");
        }
        [Test]
        public void AddMethod_ShouldThrowException_NotEnoughtCapacity_InvalidData()
        {
            var manager = new RobotManager(22);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);
            Robot robot3 = new Robot("jelezen robot", 10000);

            manager.Add(robot);
            manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot3), "Not enough capacity!");
        }
        [Test]
        public void RemoveMethod_ShouldRemove_ValidData()
        {
            var manager = new RobotManager(22);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);

            manager.Add(robot);
            manager.Add(robot2);
            manager.Remove(robot.Name);

            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void RemoveMethod_ShouldThrowException_InvalidData()
        {
            var manager = new RobotManager(22);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("mitko"), $"Robot with the name mitko doesn't exist!");
        }
        [Test]
        public void WorkMethod_ShouldDecreaseRobotBattery_ValidData()
        {
            var manager = new RobotManager(22);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);

            manager.Add(robot);
            manager.Add(robot2);
            manager.Work(robot2.Name, "bezraboten", robot2.Battery - 200);

            Assert.AreEqual(200, robot2.Battery);
        }
        [Test]
        public void WorkMethod_ShouldThrowException_NotEnoughtBatery_InvalidData()
        {
            var manager = new RobotManager(22);
            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);

            manager.Add(robot);
            manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => manager.Work(robot.Name, "bezraboten", robot.Battery + 200), $"{robot.Name} doesn't have enough battery!");
        }
        [Test]
        public void WorkMethod_ShouldThrowException_NullNmae_InvalidData()
        {
            var manager = new RobotManager(22);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Kircho", "bezraboten", 200), $"Robot with the name Kircho doesn't exist!");
        }
        [Test]
        public void ChargeMethod_ShouldThrowException_NullNmae_InvalidData()
        {
            var manager = new RobotManager(22);

            Assert.Throws<InvalidOperationException>(() => manager.Charge("Kircho"), $"Robot with the name Kircho doesn't exist!");
        }
        [Test]
        public void ChargeMethod_ShouldCharge_ValidData()
        {
            var manager = new RobotManager(22);

            Robot robot = new Robot("plastmasow robot", 20000);
            Robot robot2 = new Robot("jelezen robot", 15000);

            manager.Add(robot);
            manager.Add(robot2);
            manager.Work(robot2.Name, "bezraboten", robot2.Battery - 200);
            manager.Charge(robot2.Name);

            Assert.AreEqual(robot2.MaximumBattery, robot2.Battery);
        }
    }
}
