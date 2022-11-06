namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        Warrior first;
        Warrior second;
        Arena arena;

        [SetUp]
        public void Setup()
        {
            first = new Warrior("First", 25, 70);
            second = new Warrior("Second", 20, 65);
        }

        [Test]
        public void Constructor_InitializesTheCollection()
        {
            Arena arena = new Arena();
            List<Warrior> list = new List<Warrior>();
            CollectionAssert.AreEqual(list, arena.Warriors);
        }

        [Test]
        public void PropertyWarriors_ReturnsCorrectWarriorObjects()
        {
            arena = new Arena();
            arena.Enroll(first);
            arena.Enroll(second);
            List<Warrior> expectedWarriors = new List<Warrior>() { first, second };            
            Assert.That(expectedWarriors, Is.EquivalentTo(arena.Warriors));
        }              

        [Test]
        public void Enroll_IncreasesWarriorsCount()
        {
            arena = new Arena();
            arena.Enroll(first);
            arena.Enroll(second);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void Enroll_CantAddWarriorWithExistingName()
        {
            arena = new Arena();
            arena.Enroll(first);            
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(first));
        }

        [Test]
        public void Fight_AttackerNotPresentInTheArenaCantFight()
        {
            arena = new Arena();
            arena.Enroll(first);
            arena.Enroll(second);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Missing attacker", second.Name));            
        }

        [Test]
        public void Fight_DefenderNotPresentInTheArenaCantFight()
        {
            arena = new Arena();
            arena.Enroll(first);
            arena.Enroll(second);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(first.Name, "Missing defender"));
        }


        [Test]
        public void Fight_TwoWarriorsFightAsExpected()
        {
            arena = new Arena();
            arena.Enroll(first);
            arena.Enroll(second);

            int expectedHpFirst = first.HP - second.Damage;
            int expectedHpSecond = second.HP - first.Damage;

            arena.Fight(first.Name, second.Name);
            Assert.IsTrue(first.HP == expectedHpFirst && second.HP == expectedHpSecond);
        }
    }
}
