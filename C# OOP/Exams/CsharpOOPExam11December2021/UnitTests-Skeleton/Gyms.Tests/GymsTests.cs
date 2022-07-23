using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_Athlete_Constructor()
        {
            Athlete athlete = new Athlete("Misho mishow");

            Assert.AreEqual("Misho mishow", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }
        [Test]
        public void GymName_ValidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Assert.AreEqual("NqkuwFitnes", gym.Name);
        }
        [Test]
        public void GymName_InvalidData()
        {
            Gym gym;
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(null, 200));
        }
        [Test]
        public void GymName_WithEmptyString_InvalidData()
        {
            Gym gym;
            Assert.Throws<ArgumentNullException>(() => gym = new Gym("", 200));
        }
        [Test]
        public void GymCapacity_ValidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Assert.AreEqual(200, gym.Capacity);
        }
        [Test]
        public void GymCapacity_InvalidData()
        {
            Gym gym;
            Assert.Throws<ArgumentException>(() => gym = new Gym("NqkuwFitnes", -200));
            Assert.Throws<ArgumentException>(() => gym = new Gym("NqkuwFitnes", -1));
        }
        [Test]
        public void Test_CountMethod()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);

            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void AddAthleteMethod_ShouldAddAthlete_ValidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);
        }
        [Test]
        public void AddAthleteMethod_ShouldThrowException_InvalidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 2);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");
            Athlete athlete3 = new Athlete("Misho3 mishow3");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete3));
        }
        [Test]
        public void RemoveAthleteMethod_ShouldRemoveAthlete_ValidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");
            Athlete athlete3 = new Athlete("Misho3 mishow3");
            Athlete athlete4 = new Athlete("Misho4 mishow4");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.AddAthlete(athlete4);

            gym.RemoveAthlete("Misho mishow");
            gym.RemoveAthlete("Misho2 mishow2");

            Assert.AreEqual(2, gym.Count);
        }
        [Test]
        public void RemoveAthleteMethod_ShouldThrowException_InvalidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");
            Athlete athlete3 = new Athlete("Misho3 mishow3");
            Athlete athlete4 = new Athlete("Misho4 mishow4");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Vanko"));
        }
        [Test]
        public void InjureAthleteMethod_ShouldInjureAthlete_ValidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Athlete returnedAthlete = gym.InjureAthlete("Misho mishow");

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreSame(athlete, returnedAthlete);
        }
        [Test]
        public void InjureAthleteMethod_ShouldThrowException_InvalidData()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Vanko"));
        }
        [Test]
        public void ReportMethod_ShouldReturnDataAsString()
        {
            Gym gym = new Gym("NqkuwFitnes", 200);
            Athlete athlete = new Athlete("Misho mishow");
            Athlete athlete2 = new Athlete("Misho2 mishow2");
            Athlete athlete3 = new Athlete("Misho3 mishow3");
            Athlete athlete4 = new Athlete("Misho4 mishow4");
            Athlete athlete5 = new Athlete("Misho5 mishow5");
            Athlete athlete6 = new Athlete("Misho6 mishow6");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.AddAthlete(athlete4);
            gym.AddAthlete(athlete5);
            gym.AddAthlete(athlete6);

            gym.InjureAthlete("Misho2 mishow2");
            gym.InjureAthlete("Misho3 mishow3");
            gym.InjureAthlete("Misho4 mishow4");

            string report = gym.Report();

            Assert.AreEqual("Active athletes at NqkuwFitnes: Misho mishow, Misho5 mishow5, Misho6 mishow6", report);
        }
    }
}
