namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CtorShouldCreateEmptyList()
        {
            Arena arena = new Arena();
            CollectionAssert.AreEqual(arena.Warriors, new List<Warrior>());
        }
        [Test]
        public void CountShouldReturnTheActualCountOfTheWarriors()
        {
            Arena arena = new Arena();
            Assert.That(arena.Count == 0);
        }
        [Test]
        public void EnrollShouldThrowExceptionIfTheWarriorAlreadyExist()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Name", 10, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }
        [Test]
        public void FightShouldThrowExceptionIfAttackerNameIsMissing()
        {
            Arena arena = new Arena();
            Warrior deffender = new Warrior("Name", 10, 100);
            arena.Enroll(deffender);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Name2", "Name"));
            Assert.That(ex.Message == $"There is no fighter with name Name2 enrolled for the fights!");
        }
        [Test]
        public void FightShouldThrowExceptionIfNameIsMissing()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Name", 10, 100);
            arena.Enroll(attacker);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Name", "Name2"));
            Assert.That(ex.Message == $"There is no fighter with name Name2 enrolled for the fights!");
        }
        [Test]
        public void FightShouldNotThrowExceptionIfBothNamesExistInTheArena()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Name", 10, 100);
            Warrior deffender = new Warrior("Name2", 10, 100);
            arena.Enroll(attacker);
            arena.Enroll(deffender);
            arena.Fight("Name", "Name2");
            Assert.That(attacker.HP == 90);
            Assert.That(deffender.HP == 90);
        }
    }
}
