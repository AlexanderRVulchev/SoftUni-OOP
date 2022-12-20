using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private const string DEF_WEAPON_NAME = "Laser";
            private const double DEF_WEAPON_PRICE = 1000.0;
            private const int DEF_WEAPON_DESTRUCTION = 5;

            private const string DEF_PLANET_NAME = "Earth";
            private const double DEF_PLANET_BUDGET = 500.0;


            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void Setup()
            {
                weapon = new Weapon(DEF_WEAPON_NAME, DEF_WEAPON_PRICE, DEF_WEAPON_DESTRUCTION);
                planet = new Planet(DEF_PLANET_NAME, DEF_PLANET_BUDGET);
            }

            // Testing class Weapon

            [Test]
            public void Weapon_Constructor_AssignsValuesProprly()
            {
                weapon = new Weapon(DEF_WEAPON_NAME, DEF_WEAPON_PRICE, DEF_WEAPON_DESTRUCTION);
                Assert.True(weapon.Name == DEF_WEAPON_NAME &&
                            weapon.Price == DEF_WEAPON_PRICE &&
                            weapon.DestructionLevel == DEF_WEAPON_DESTRUCTION);
            }

            [Test]
            public void Weapon_PropertyPrice_CantBeNegative()
            {
                Assert.Throws<ArgumentException>(() => weapon = new Weapon(DEF_WEAPON_NAME, -1, DEF_WEAPON_DESTRUCTION));
            }

            [TestCase(1)]
            [TestCase(10)]
            [TestCase(100)]
            public void Weapon_GetterIsNuclear_TrueWhenEqualOrAbove10(int destruction)
            {
                bool expectedState = destruction >= 10;
                weapon = new Weapon(DEF_WEAPON_NAME, DEF_WEAPON_PRICE, destruction);
                Assert.AreEqual(expectedState, weapon.IsNuclear);
            }

            [Test]
            public void Weapon_IncreaseDestructionLevel_IncreasesProperly()
            {
                weapon = new Weapon(DEF_WEAPON_NAME, DEF_WEAPON_PRICE, DEF_WEAPON_DESTRUCTION);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(weapon.DestructionLevel, DEF_WEAPON_DESTRUCTION + 1);
            }

            // Testing class Planet

            [Test]
            public void Planet_Constructor_CreatesObjectProperly()
            {
                Assert.True(planet.Name == DEF_PLANET_NAME &&
                            planet.Budget == DEF_PLANET_BUDGET &&
                            planet.Weapons != null);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Planet_Name_CantBeNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() => planet = new Planet(name, DEF_PLANET_BUDGET));
            }

            [TestCase(-4.5)]
            public void Planet_Budget_CantBeNegative(double negativeBudget)
            {
                Assert.Throws<ArgumentException>(() => planet = new Planet(DEF_PLANET_NAME, negativeBudget));
            }

            [Test]
            public void Planet_MilitaryPowerRatio_ReturnProperValue()
            {
                Weapon weapon2 = new Weapon("Blaster", 650, 15);
                double expectedValue = weapon.DestructionLevel + weapon2.DestructionLevel;
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(planet.MilitaryPowerRatio, expectedValue);
            }

            [TestCase(124)]
            [TestCase(54.4)]
            public void Planet_Profit_IncreasesBudgetProperly(double increaseAmount)
            {
                planet.Profit(increaseAmount);
                Assert.AreEqual(DEF_PLANET_BUDGET + increaseAmount, planet.Budget);
            }

            [TestCase(50)]
            public void Planet_SpendFunds_DecreasesBudgetProperly(double decreaseAmount)
            {
                planet.SpendFunds(decreaseAmount);
                Assert.AreEqual(DEF_PLANET_BUDGET - decreaseAmount, planet.Budget);
            }

            [TestCase(DEF_PLANET_BUDGET + 25)]
            public void Planet_SpendFunds_ThrowsIfNotEnoughFunds(double amount)
            {
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(amount));
            }

            [Test]
            public void Planet_AddWeapon_WorksProperly()
            {
                planet.AddWeapon(weapon);
                Assert.IsTrue(planet.Weapons.Count == 1);
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            }

            [Test]
            public void Planet_RemoveWeapon_WorksProperly()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);
                Assert.IsTrue(planet.Weapons.Count == 0);
            }

            [Test]
            public void Planet_UpgradeWeapon_ThrowsForNonExistantWeapon()
            {
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Missing weapon"));
            }

            [Test]
            public void Planet_UpgradeWeapon_IncreasesDestructionLevelBy1()
            {
                int expectedDestruction = DEF_WEAPON_DESTRUCTION + 1;
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(weapon.DestructionLevel, expectedDestruction);
            }

            [Test]
            public void Planet_DestructOpponent_ThrowsIfStrongerEnemyIsAttacked()
            {
                Planet opponent = new Planet("Jupiter", 2500);
                Weapon strongWeapon = new Weapon("Death Ray", 850, 150);
                opponent.AddWeapon(strongWeapon);
                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
            }

            [Test]
            public void Planet_DestructOpponent_ReturnsProperMessage()
            {
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("Mars", 250);
                string output = planet.DestructOpponent(opponent);
                Assert.AreEqual(output, $"{opponent.Name} is destructed!");
            }
        }
    }
}
