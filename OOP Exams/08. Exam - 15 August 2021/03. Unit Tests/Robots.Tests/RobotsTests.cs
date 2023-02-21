namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private string DEF_ROBOT_NAME = "Robot name";
        private int DEF_ROBOT_MAXBATTERY = 50;
        private int DEF_MANAGER_CAPACITY = 2;

        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void Setup()
        {
            robot = new Robot(DEF_ROBOT_NAME, DEF_ROBOT_MAXBATTERY);
            manager = new RobotManager(DEF_MANAGER_CAPACITY);
            manager.Add(robot);
        }

        [Test]
        public void Robot_Constructor_CreatesObjectProperly()
        {
            Assert.AreEqual(robot.Name, DEF_ROBOT_NAME);
            Assert.AreEqual(robot.MaximumBattery, DEF_ROBOT_MAXBATTERY);
            Assert.AreEqual(robot.Battery, DEF_ROBOT_MAXBATTERY);
        }

        [Test]
        public void Manager_Constructor_CreatesObjectProperly()
        {
            Assert.AreEqual(manager.Capacity, DEF_MANAGER_CAPACITY);            
        }
        
        [Test]
        public void Capacity_ThrowsForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => manager = new RobotManager(-1));
        }
        
        [Test]
        public void Add_IncreasesCount()
        {            
            Assert.AreEqual(manager.Count, 1);
        }

        [Test]
        public void Add_ThrowsForRobotWithExistingName()
        {            
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot(robot.Name, 15)));
        }

        [Test]
        public void Add_ThrowsForNotEnoughCapacity()
        {
            manager.Add(new Robot("Second robot", 10));
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("Third robot", 20)));
        }
        
        [Test]
        public void Remove_DecreasesCount()
        {
            manager.Remove(robot.Name);
            Assert.AreEqual(manager.Count, 0);
        }

        [Test]
        public void Remove_ThrowsForMissingRobotName()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Remove("Missing name"));
        }

        [Test]
        public void Work_DecreasesBattery()
        {
            int expectedBattery = DEF_ROBOT_MAXBATTERY - 10;
            manager.Work(robot.Name, "job", 10);
            Assert.AreEqual(robot.Battery, expectedBattery);
        }

        [Test]
        public void Work_ThrowsForMissingRobotName()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("Missing name", "job", 10));
        }

        [Test]
        public void Work_ThrowsForNotEnoughBattery()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work(robot.Name, "job", DEF_ROBOT_MAXBATTERY + 10));
        }

        [Test]
        public void Charge_FillsUpTheBatteryCharge()
        {
            manager.Work(robot.Name, "job", 20);
            manager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery, DEF_ROBOT_MAXBATTERY);
        }

        [Test]
        public void Charge_ThrowsForMissingRobotName()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Missing name"));
        }
    }
}
