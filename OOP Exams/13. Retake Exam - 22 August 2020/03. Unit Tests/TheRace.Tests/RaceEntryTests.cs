using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private const string CAR_MODEL = "Car model";
        private const int CAR_HORSEPOWER = 200;
        private const double CAR_CUBIC_CENTIMETERS = 1500;
        private const string DRIVER_NAME = "Driver name";

        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;
        string addDriverResult;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar(CAR_MODEL, CAR_HORSEPOWER, CAR_CUBIC_CENTIMETERS);
            driver = new UnitDriver(DRIVER_NAME, car);
            race = new RaceEntry();
            addDriverResult = race.AddDriver(driver);
        }

        [Test]
        public void AddDriver_AddsADriverToTheCollection()
        {
            string expectedResult = $"Driver {driver.Name} added in race.";
            Assert.AreEqual(expectedResult, addDriverResult);
            Assert.AreEqual(race.Counter, 1);
        }

        [Test]
        public void AddDriver_ThrowsForNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsIfDriverNameAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void Calculate_ThrowsForNotEnoughParticipants()
        {
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void Calculate_ReturnsCorrectValueForAverageHorsepower()
        {
            UnitDriver secondDriver = new UnitDriver("Second", new UnitCar("Token model", 300, 2000));
            race.AddDriver(secondDriver);
            double expectedAverageHorsePower = (CAR_HORSEPOWER + 300) / 2;
            Assert.AreEqual(expectedAverageHorsePower, race.CalculateAverageHorsePower());            
        }
    }
}