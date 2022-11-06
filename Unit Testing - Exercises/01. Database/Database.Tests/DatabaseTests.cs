namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [Test]
        public void TheConstructorTakesNoMoreThan16Integers()
        {
            TestDelegate action = () => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            Assert.Throws<InvalidOperationException>(action, "It is possible to add more than 16 integers");
        }

        [Test]
        public void AddOperationIncreasesCountByOne()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Add(6);
            Assert.AreEqual(6, database.Count, "Add operation doesn't increase count by 1.");
        }

        [Test]
        public void RemoveOperationDecreasesCountByOne()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Remove();
            Assert.AreEqual(database.Count, 4, "Remove operation doesn't decrease count by 1.");
        }

        [Test]
        public void AddOperationCannotIncreaseCountOver16()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            TestDelegate action = () => database.Add(17);
            Assert.Throws<InvalidOperationException>(action, "Add operation can increase count over 16.");
        }

        [Test]
        public void CannotRemoveAnElementFromAnEmptyDatabase()
        {
            database = new Database();
            TestDelegate action = () => database.Remove();
            Assert.Throws<InvalidOperationException>(action, "It is possible to remove an element from an empty database.");
        }

        [Test]
        public void FetchOperationReturnsElementsAsArray()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8);
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] testArray = database.Fetch();
            Assert.AreEqual(expectedArray, testArray, "Fetch doesn't return correct elements.");
        }
    }
}