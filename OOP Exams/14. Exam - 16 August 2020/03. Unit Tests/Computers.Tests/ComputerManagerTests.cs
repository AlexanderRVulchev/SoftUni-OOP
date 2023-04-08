using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string DEF_COMPUTER_MANUFACTURER = "Manufacturer";
        private const string DEF_COMPUTER_MODEL = "Model";
        private const decimal DEF_COMPUTER_PRICE = 1000m;



        private Computer computer;
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            computer = new Computer(DEF_COMPUTER_MANUFACTURER, DEF_COMPUTER_MODEL, DEF_COMPUTER_PRICE);
            manager = new ComputerManager();
            manager.AddComputer(computer);
        }

        [Test]
        public void ValidatingNullValuesOfArguments()
        {
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, DEF_COMPUTER_MODEL));
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(DEF_COMPUTER_MANUFACTURER, null));
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));
        }

        [Test]
        public void AddComputer_AddsObjectToTheCollection()
        {
            Assert.AreEqual(manager.Count, 1);
            Assert.AreEqual(manager.Computers.Count, 1);
            Assert.AreSame(manager.Computers.First(), computer);
        }

        [Test]
        public void AddComputer_ThrowsForAlreadyExistingComputer()
        {
            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void RemoveComputer_RemovesObjectCorrectly()
        {
            Computer removed = manager.RemoveComputer(DEF_COMPUTER_MANUFACTURER, DEF_COMPUTER_MODEL);
            Assert.AreSame(computer, removed);
            Assert.AreEqual(manager.Count, 0);
            Assert.AreEqual(manager.Computers.Count, 0);
        }

        [Test]
        public void RemoveComputer_ThrowsForNonExistentComputerParameters()
        {
            Assert.Throws<ArgumentException>(() => manager.RemoveComputer(DEF_COMPUTER_MANUFACTURER, "Token model"));
            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("Token manufacturer", DEF_COMPUTER_MODEL));
        }

        public void GetComputer_ReturnsCorrectObject()
        {
            Computer gotComputer = manager.GetComputer(DEF_COMPUTER_MANUFACTURER, DEF_COMPUTER_MODEL);
            Assert.AreSame(gotComputer, computer);
        }

        public void GetComputer_ThrowsForNonExistingComputer()
        {
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Missing manufacturer", "Missing model"));
        }

        public void GetComputersByManufacturer_ReturnsCorrectObject()
        {
            Computer computer2 = new Computer(DEF_COMPUTER_MANUFACTURER, "Token model", 1500);
            manager.AddComputer(computer2);
            List<Computer> expectedComputers = new List<Computer>();
            expectedComputers.Add(computer);
            expectedComputers.Add(computer2);
            List<Computer> resultComputers = manager.GetComputersByManufacturer(DEF_COMPUTER_MANUFACTURER).ToList();
            Assert.AreEqual(resultComputers, expectedComputers);
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsEmptyCollection()
        {
            manager.AddComputer(new Computer("second manufacturer", "second model", 1500));
            manager.AddComputer(new Computer("third manufacturer", "third model", 2000));
            List<Computer> computers = manager.GetComputersByManufacturer("non-existing manufacturer").ToList();
            Assert.IsEmpty(computers);            
        }
    }
}