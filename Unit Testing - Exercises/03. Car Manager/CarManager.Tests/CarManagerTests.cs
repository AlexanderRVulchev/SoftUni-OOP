namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class CarManagerTests
    {
        private const string DEF_MAKE = "Ferarri";
        private const string DEF_MODEL = "812 GTS";
        private const double DEF_FUELCONSUMPTION = 15.8;
        private const double DEF_FUELCAPACITY = 92.0;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(DEF_MAKE, DEF_MODEL, DEF_FUELCONSUMPTION, DEF_FUELCAPACITY);
        }

        [Test]
        public void Constructor_CreatesACarProperly()
        {
            Assert.AreEqual(DEF_MODEL, car.Model, "Constructor: Model error");
            Assert.AreEqual(DEF_FUELCONSUMPTION, car.FuelConsumption, "Constructor: Consumption error");
            Assert.AreEqual(DEF_MAKE, car.Make, "Constructor: Make error");
            Assert.AreEqual(DEF_FUELCAPACITY, car.FuelCapacity, "Constructor: Capacity error");
            Assert.AreEqual(car.FuelAmount, 0, "Constructor: Amount error");
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyMake_CantBeNullOrEmpty(string make)
        {
            TestDelegate action = () => car = new Car(make, DEF_MODEL, DEF_FUELCONSUMPTION, DEF_FUELCAPACITY);
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyModel_CantBeNullOrEmpty(string model)
        {
            TestDelegate action = () => car = new Car(DEF_MAKE, model, DEF_FUELCONSUMPTION, DEF_FUELCAPACITY);
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase(0.0)]
        [TestCase(-15.2)]
        public void PropertyFuelConsumption_CantBeZeroOrNegative(double fuelConsuption)
        {
            TestDelegate action = () => car = new Car(DEF_MAKE, DEF_MODEL, fuelConsuption, DEF_FUELCAPACITY);
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase(0.0)]
        [TestCase(-5.5)]
        public void PropertyFuelCapacity_CantBeZeroOrNegative(double fuelCapacity)
        {
            TestDelegate action = () => car = new Car(DEF_MAKE, DEF_MODEL, DEF_FUELCONSUMPTION, fuelCapacity);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void PropertyFuelAmount_CantBeNegative()
        {
            TestDelegate action = () => car.Drive(20);
            Assert.Throws<InvalidOperationException>(action);
        }

        [TestCase(0.0)]
        [TestCase(-10.1)]
        public void Refuel_FuelAmountCantBeZeroOrNegative(double amount)
        {
            TestDelegate action = () => car.Refuel(amount);
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase(1.0)]
        [TestCase(20.65)]
        [TestCase(40.99)]
        public void Refuel_IncreasesCorrectlyTheFuelAmount(double fuel)
        {
            double expectedFuelAmount = car.FuelAmount + fuel;
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, expectedFuelAmount);
        }

        [Test]
        public void Refuel_FuelAmountCantBeHigherThanFuelCapacity()
        {
            double fuel = DEF_FUELCAPACITY + 10;
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, DEF_FUELCAPACITY);
        }


        [TestCase(1)]
        [TestCase(24.5)]
        [TestCase(31.375)]
        public void Drive_DecreasesFuelAmountProperly(double distance)
        {
            car.Refuel(50);
            double expectedFuelAmount = car.FuelAmount - ((distance / 100) * car.FuelConsumption);
            car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}