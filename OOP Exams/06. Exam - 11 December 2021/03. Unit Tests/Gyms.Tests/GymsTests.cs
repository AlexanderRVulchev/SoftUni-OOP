namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class GymsTests
    {
        private const string DEF_ATHLETE_NAME = "Test athlete name";
        private const string DEF_GYM_NAME = "Test gym name";
        private const int DEF_GYM_SIZE = 2;

        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void Setup()
        {
            athlete = new Athlete(DEF_ATHLETE_NAME);
            gym = new Gym(DEF_GYM_NAME, DEF_GYM_SIZE);
            gym.AddAthlete(athlete);
        }

        [Test]
        public void Athlete_Constructor_CreatesObjectProperly()
        {
            Assert.True(athlete.FullName == DEF_ATHLETE_NAME);
            Assert.True(!athlete.IsInjured);                        
        }

        [Test]
        public void Gym_Constructor_CreatesObjectProperly()
        {
            gym = new Gym(DEF_GYM_NAME, DEF_GYM_SIZE);
            Assert.True(gym.Name == DEF_GYM_NAME);
            Assert.True(gym.Capacity == DEF_GYM_SIZE);
            Assert.True(gym.Count == 0);                        
        }

        [TestCase("")]
        [TestCase(null)]
        public void GymName_CantBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, DEF_GYM_SIZE));
        }

        [Test]
        public void GymCapacity_CantBeNegative()
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym(DEF_GYM_NAME, -1));
        }

        [Test]
        public void Gym_AddAthlete_IncreasesGetterCount()
        {
            Assert.AreEqual(gym.Count, 1);
        }

        [Test]
        public void Gym_AddAthlete_ThrowsForFullGym()
        {
            gym.AddAthlete(new Athlete("Athlete 2"));
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Athlete 3")));
        }

        [Test]
        public void Gym_RemoveAthlete_DecreasesGetterCount()
        {
            gym.RemoveAthlete(DEF_ATHLETE_NAME);
            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void Gym_RemoveAthlete_ThrowsForNonExistentAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Fake name"));
        }

        [Test]
        public void Gym_InjureAthlete_ThrowsForNonExistentAthlete()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Fake name"));
        }

        [Test]
        public void Gym_InjureAthlete_SetsIsInjuredToTrue()
        {
            Athlete injured = gym.InjureAthlete(DEF_ATHLETE_NAME);
            Assert.IsTrue(injured.IsInjured && injured.FullName == DEF_ATHLETE_NAME);
        }

        [Test]
        public void Gym_Report_ReturnsCorrectInfo()
        {
            Athlete athlete2 = new Athlete("Token name");
            List<Athlete> athletes = new List<Athlete>() { athlete, athlete2 };
            gym.AddAthlete(athlete2);
            gym.InjureAthlete(athlete2.FullName);
            string expectedString = $"Active athletes at {DEF_GYM_NAME}: {string.Join(", ", athletes.Where(x => !x.IsInjured).Select(x => x.FullName))}";
            Assert.AreEqual(expectedString, gym.Report());
        }
    }
}
