namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            Person[] people = new Person[14];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(i, ((char)('A' + i)).ToString());
            database = new Database(people);
        }

        [Test]
        public void Constructor_CannotTakeMoreThan16People()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(i, ((char)('A' + i)).ToString());            
            Assert.Throws<ArgumentException>(() => database = new Database(people));
        }                     

        [Test]
        public void Add_IncreasesTheCollectionCount()
        {
            database.Add(new Person(14, "Joe"));
            Assert.AreEqual(database.Count, 15);
        }

        [Test]
        public void Add_CannotAddPersonWithExistingName()
        {            
            Assert.That(() => database.Add(new Person(100, "A")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_CannotAddPersonWithExistingID()
        {            
            Assert.That(() => database.Add(new Person(1, "John")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_CannotExceedMaximumArrayCount()
        {
            database.Add(new Person(14, "Fourteen"));
            database.Add(new Person(15, "Sixteen"));            
            Assert.That(() => database.Add(new Person(16, "Error")), Throws.InvalidOperationException);
        }
                
        [Test]
        public void Add_AddsPersonToTheCollection()
        {
            Person person = new Person(14, "Jimmy");
            database.Add(person);
            Person expected = database.FindById(14);
            Assert.AreEqual(person, expected);
        }
                
        [Test]
        public void Remove_RemovesLastPersonFromTheCollection()
        {
            Person person = new Person(14, "Lilly");
            database.Add(person);
            database.Remove();            
            Assert.That(() => database.FindByUsername("Lilly"), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_CantFunctionOnEmptyCollection()
        {
            Database database = new Database();            
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_DecreasesTheCollectionCount()
        {
            int expectedCount = database.Count - 1;
            database.Remove();
            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void FindByUsername_ThrowsExceptionIfUsernameNotPresent()
        {            
            Assert.That(() => database.FindByUsername("Misho"), Throws.InvalidOperationException);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_UserCantBeNull(string username)
        {            
            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);
        }
                
        [Test]
        public void FindByUsername_ReturnsTheCorrectPerson()
        {
            Person personToFind = database.FindByUsername("A");
            Assert.AreEqual(personToFind.UserName, "A");
        }
               
        [Test]
        public void FindById_ReturnsTheCorrectPerson()
        {
            Person personToFind = database.FindById(4);
            Assert.AreEqual(personToFind.Id, 4);
        }

        [Test]
        public void FindById_IdMustBePositiveNumber()
        {            
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FindById_ThrowsExceptionIfNonExistingIdIsPassed()
        {            
            Assert.That(() => database.FindById(1337), Throws.InvalidOperationException);
        }
    }
}