namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private const string DEF_WARRIOR_NAME = "Hero";
        private const int DEF_WARRIOR_DAMAGE = 10;
        private const int DEF_WARRIOR_HP = 50;

        private const string DEF_ENEMY_NAME = "Enemy";
        private const int DEF_ENEMY_DAMAGE = 10;
        private const int DEF_ENEMY_HP = 50;

        Warrior warrior;
        Warrior enemy;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(DEF_WARRIOR_NAME, DEF_WARRIOR_DAMAGE, DEF_WARRIOR_HP);
            enemy = new Warrior(DEF_ENEMY_NAME, DEF_ENEMY_DAMAGE, DEF_ENEMY_HP);
        }

        [Test]
        public void Constructor_CreatesAnObjectProperly()
        {
            Assert.AreEqual(warrior.Name, DEF_WARRIOR_NAME);
            Assert.AreEqual(warrior.Damage, DEF_WARRIOR_DAMAGE);
            Assert.AreEqual(warrior.HP, DEF_WARRIOR_HP);
        }

        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void PropertyName_CannotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, DEF_ENEMY_DAMAGE, DEF_WARRIOR_HP));
        }

        [TestCase(0)]
        [TestCase(-15)]
        public void PropertyDamage_CantBeNegativeOrZero(int damage)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(DEF_WARRIOR_NAME, damage, DEF_WARRIOR_HP));
        }

        [TestCase(-15)]
        public void PropertyHP_CannotBeNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(DEF_WARRIOR_NAME, DEF_WARRIOR_DAMAGE, hp));
        }

        [Test]
        public void Attack_DecreasesBothWarriorsHpCorrectly()
        {
            int expectedWarriorHp = warrior.HP - enemy.Damage;
            int expectedEnemyHp = enemy.HP - warrior.Damage;
            warrior.Attack(enemy);
            Assert.That(enemy.HP == expectedEnemyHp && warrior.HP == expectedWarriorHp);

        }

        [Test]
        public void Attack_WarriorCantAttackIfHisHpIsTooLow()
        {
            warrior = new Warrior(DEF_WARRIOR_NAME, DEF_WARRIOR_DAMAGE, 15);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void Attack_WarriorCantAttackAWeakEnemy()
        {
            enemy = new Warrior(DEF_ENEMY_NAME, DEF_ENEMY_DAMAGE, 15);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void Attack_WarriorCantAttackATooStrongEnemy()
        {
            enemy = new Warrior(DEF_ENEMY_NAME, 65, DEF_ENEMY_HP);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void Attack_EnemyHpCantDecreaseBelowZero()
        {
            warrior = new Warrior(DEF_WARRIOR_NAME, DEF_ENEMY_HP + 15, DEF_WARRIOR_HP);
            warrior.Attack(enemy);
            Assert.AreEqual(enemy.HP, 0);
        }
    }
}