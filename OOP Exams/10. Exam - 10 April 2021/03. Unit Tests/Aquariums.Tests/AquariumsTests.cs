namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        private const string DEF_FISH_NAME = "Fish name";
        private const string DEF_AQUA_NAME = "Aquarium name";
        private const int DEF_AQUA_CAPACITY = 2;

        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            fish = new Fish(DEF_FISH_NAME);
            aquarium = new Aquarium(DEF_AQUA_NAME, DEF_AQUA_CAPACITY);
            aquarium.Add(fish);
        }

        [Test]
        public void Fish_Constructor_CreatesObjectProperly()
        {
            Assert.AreEqual(fish.Name, DEF_FISH_NAME);
            Assert.AreEqual(fish.Available, true);
        }

        [Test]
        public void Aquarium_Constructor_CreatesObjectProperly()
        {
            aquarium = new Aquarium(DEF_AQUA_NAME, DEF_AQUA_CAPACITY);
            Assert.AreEqual(aquarium.Name, DEF_AQUA_NAME);
            Assert.AreEqual(aquarium.Capacity, DEF_AQUA_CAPACITY);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyName_ThrowsForNullOrEmptyValue(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, DEF_AQUA_CAPACITY));
        }

        [Test]
        public void PropertyCapacity_ThrowsForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(DEF_AQUA_NAME, -1));
        }

        [Test]
        public void Add_IncreasesCountByOne()
        {
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void Add_ThrowsWhenAtFullCapacity()
        {
            aquarium = new Aquarium(DEF_AQUA_NAME, 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void RemoveFish_DecreasesCountByOne()
        {
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void Removefish_ThrowsForNonExistingFish()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Missing fish name"));
        }

        [Test]
        public void SellFish_SetsAvailablePropertyToFalse()
        {
            Fish soldFish = aquarium.SellFish(fish.Name);
            Assert.AreEqual(fish.Available, false);
            Assert.AreSame(fish, soldFish);
        }

        [Test]
        public void SellFish_ThrowsForNonExistingFish()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Missing fish name"));
        }

        [Test]
        public void Report_ReturnsCorrectString()
        {
            Fish fish2 = new Fish("Fish name 2");
            aquarium.Add(fish2);

            List<Fish> listOfFish = new List<Fish>();
            listOfFish.Add(fish);
            listOfFish.Add(fish2);
            string expectedReport = $"Fish available at {aquarium.Name}: {string.Join(", ", listOfFish.Select(f => f.Name))}";
            Assert.AreEqual(aquarium.Report(), expectedReport);
        }
    }
}
