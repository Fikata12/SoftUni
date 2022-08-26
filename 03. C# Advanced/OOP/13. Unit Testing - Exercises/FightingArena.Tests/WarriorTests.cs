namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            name = "Name";
            damage = 10;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void TestAllSetttersThroughTheCtor()
        {
            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void NameShouldThrowExceptionIfInputDataIsNullWhiteSpaceOrEmpty(string inputData)
        {
            name = inputData;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void DamageShouldThrowExceptionIfInputDataIsZeroOrNegative(int inputData)
        {
            damage = inputData;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }
        [TestCase(-1)]
        public void HpShouldThrowExceptionIfInputDataIsNegative(int inputData)
        {
            hp = inputData;
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShoudThrowExceptionIfHpIsLowerThanMIN_ATTACK_HP(int inputData)
        {
            hp = inputData;
            warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Name2", 10, 100)));
        }
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShoudThrowExceptionIfAttackedWarriorHpIsLowerThanMIN_ATTACK_HP(int inputData)
        {
            warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Name2", 10, inputData)));
        }
        [Test]
        public void AttackShoudThrowExceptionIfAttackedWarriorDamageIsHigherThanAttackerHp()
        {
            warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Name2", 101, 100)));
        }
        [Test]
        public void AttackShoudSetAttackedWarriorHpToZeroIfAttackerDamageIsHigherThanHisHp()
        {
            damage = 100;  
            warrior = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior("Name2", 10, 80);
            warrior.Attack(warrior2);
            Assert.That(warrior2.HP == 0);
        }
        [Test]
        public void AttackShoudDecreaseAttackerHpByAttackedWarriorDamage()
        {
            damage = 100;
            warrior = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior("Name2", 10, 80);
            warrior.Attack(warrior2);
            Assert.That(warrior.HP == 90);
        }
        [Test]
        public void AttackShouldDecreaseAttackedWarriorHpByAttackerDamageIfItsNotHigherThanHisHp()
        {
            Warrior warrior2 = new Warrior("Name2", 10, 100);
            warrior.Attack(warrior2);
            Assert.That(warrior2.HP == 90);
        }
    }
}