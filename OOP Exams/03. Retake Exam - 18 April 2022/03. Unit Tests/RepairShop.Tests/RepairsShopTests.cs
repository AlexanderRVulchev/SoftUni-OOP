using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private const string DEF_CAR_MODEL = "Default car";
            private const int DEF_CAR_ISSUES = 1;

            private const string DEF_GARAGE_NAME = "Default garage";
            private const int DEF_GARAGE_MECHANICS = 2;

            private Car car;
            private Garage garage;

            [SetUp]
            public void Setup()
            {
                car = new Car(DEF_CAR_MODEL, DEF_CAR_ISSUES);
                garage = new Garage(DEF_GARAGE_NAME, DEF_GARAGE_MECHANICS);
            }

            [Test]
            public void Car_Constructor_CreatesObjectProperly()
            {
                bool expectedIsFixed = false;
                car = new Car(DEF_CAR_MODEL, DEF_CAR_ISSUES);
                Assert.IsTrue(car.CarModel == DEF_CAR_MODEL &&
                              car.NumberOfIssues == DEF_CAR_ISSUES &&
                              car.IsFixed == expectedIsFixed);
            }

            [Test]
            public void Car_GetterIsFixed_ReturnsTrueWhenIssuesAreZero()
            {
                car = new Car(DEF_CAR_MODEL, 0);
                Assert.AreEqual(car.IsFixed, true);
            }

            [Test]
            public void Garage_Constructor_CreatesObjectProperly()
            {
                garage = new Garage(DEF_GARAGE_NAME, DEF_GARAGE_MECHANICS);
                Assert.IsTrue(garage.Name == DEF_GARAGE_NAME &&
                              garage.MechanicsAvailable == DEF_GARAGE_MECHANICS &&
                              garage.CarsInGarage == 0);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Garage_PropertyName_CantBeNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() => garage = new Garage(name, DEF_GARAGE_MECHANICS));
            }

            [Test]
            public void Garage_MechanicsAvailable_CantBeBelowOne()
            {
                Assert.Throws<ArgumentException>(() => garage = new Garage(DEF_GARAGE_NAME, 0));
            }

            [Test]
            public void Garage_AddCar_IncreasesCarsCount()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void Garage_AddCar_ThrowsForNotEnoughMechanics()
            {
                Car car2 = new Car("Token car", 0);
                Car car3 = new Car("Token car 2", 1);
                garage.AddCar(car);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car3));
            }

            [Test]
            public void Garage_FixCar_ThrowsForNonExistingCar()
            {
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("test model"));
            }

            [Test]
            public void Garage_FixCar_FixesTheCar()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                Assert.True(car.IsFixed);
            }

            [Test]
            public void Garage_RemoveFixedCar_ThrowsForNoFixedCarsAvailable()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }

            [Test]
            public void Garage_RemoveFixedCar_ReturnsFixedCarsProperly()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                Assert.AreEqual(1, garage.RemoveFixedCar());
            }

            [Test]
            public void Garage_Report_ReturnsCorrectString()
            {
                Car unfixedCar1 = new Car("Token model", 1);
                Car unfixedCar2 = new Car("Token model 2", 2);

                garage.AddCar(unfixedCar1);
                garage.AddCar(unfixedCar2);
                int expectedUnfixedCarsCount = 2;

                string expectedOutput = $"There are {expectedUnfixedCarsCount} which are not fixed: {unfixedCar1.CarModel}, {unfixedCar2.CarModel}.";
                Assert.AreEqual(garage.Report(), expectedOutput);
            }
        }
    }
}