using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int INITIAL_AXE_ATTACK = 2;
        private const int INITIAL_AXE_DURABILITY = 10;

        private const int INITIAL_DUMMY_ALIVE_HEALTH = 10;
        private const int INITIAL_DUMMY_DEAD_HEALTH = 0;
        private const int INITIAL_DUMMY_EXPERIENCE = 5;

        private Axe axe;
        private Dummy dummy;

        private void RunSetup(bool aliveDummy)
        {
            axe = new Axe(INITIAL_AXE_ATTACK, INITIAL_AXE_DURABILITY);

            if (aliveDummy)
                dummy = new Dummy(INITIAL_DUMMY_ALIVE_HEALTH, INITIAL_DUMMY_EXPERIENCE);
            else
                dummy = new Dummy(INITIAL_DUMMY_DEAD_HEALTH, INITIAL_DUMMY_EXPERIENCE);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            RunSetup(aliveDummy: true);
            const int EXPECTED_DUMMY_HEALTH = INITIAL_DUMMY_ALIVE_HEALTH - INITIAL_AXE_ATTACK;

            axe.Attack(dummy);
            Assert.That(dummy.Health == EXPECTED_DUMMY_HEALTH, "Dummy doesn't lose health if attacked.");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            RunSetup(aliveDummy: false);
            bool exceptionIsThrown = false;
            try
            {
                axe.Attack(dummy);
            }
            catch (InvalidOperationException)
            {
                exceptionIsThrown = true;
            }
            Assert.IsTrue(exceptionIsThrown, "Dead dummy doesn't throw an exception if attacked.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            RunSetup(aliveDummy: false);
            int getExperience = dummy.GiveExperience();
            Assert.That(getExperience, Is.EqualTo(INITIAL_DUMMY_EXPERIENCE), "Dead dummy can't give experience.");
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            RunSetup(aliveDummy: true);
            bool targetIsAliveExceptionIsThrown = false;
            try
            {
                dummy.GiveExperience();
            }
            catch (InvalidOperationException)
            {
                targetIsAliveExceptionIsThrown = true;
            }
            Assert.IsTrue(targetIsAliveExceptionIsThrown, "Alive dummy able to give experience.");
        }

    }
}