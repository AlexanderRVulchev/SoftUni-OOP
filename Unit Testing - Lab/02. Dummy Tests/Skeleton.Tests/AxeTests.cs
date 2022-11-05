using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 0);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 9, "Axe doesn't lose durability");
        }

        [Test]
        public void TestAttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 0);
            try
            {
                axe.Attack(dummy);
            }
            catch { }            
            Assert.That(axe.DurabilityPoints == 0, "Weapon isn't broken");            
        }
    }
}