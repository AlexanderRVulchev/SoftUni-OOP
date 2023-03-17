namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private const string DEF_PRESENT_NAME = "Present name";
        private const double DEF_PRESENT_MAGIC = 10;

        private Present present;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            present = new Present(DEF_PRESENT_NAME, DEF_PRESENT_MAGIC);
            bag = new Bag();
            bag.Create(present);
        }

        [Test]
        public void Present_Constructor_CreatesObjectProperly()
        {
            Assert.AreEqual(present.Name, DEF_PRESENT_NAME);
            Assert.AreEqual(present.Magic, DEF_PRESENT_MAGIC);
        }

        [Test]
        public void Create_AddsObjectToTheCollection()
        {
            Assert.AreEqual(bag.GetPresents().Count, 1);
            Assert.AreSame(bag.GetPresents().First(), present);
        }

        [Test]
        public void Create_ThrowsForNullPresent()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Create_ThrowsForAlreadyExistingPresent()
        {
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Remove_RemovesAnObjectCorrectly()
        {
            bag.Remove(present);
            Assert.AreEqual(bag.GetPresents().Count, 0);
            Assert.IsTrue(bag.GetPresent(present.Name) == null);
        }

        [Test]
        public void GetPresentWithLeastMagic_ReturnsProperObject()
        {
            Present present2 = new Present("Token name", 20);
            bag.Create(present2);
            double expectedLeastMagic = Math.Min(present.Magic, present2.Magic);
            Assert.AreEqual(expectedLeastMagic, bag.GetPresentWithLeastMagic().Magic);
        }

        [Test]
        public void GetPresent_ReturnsCorrectObject()
        {
            Assert.AreSame(bag.GetPresent(present.Name), present);
            Assert.AreSame(bag.GetPresent("Missing name"), null);            
        }
    }
}
