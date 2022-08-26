using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AfterAttack_LoosesDurability()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }
        [Test]
        public void AttackingWithBrokenAxe_ThrowsException()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);
            Assert.That(() => { axe.Attack(dummy); }, Throws.InvalidOperationException);
        }
    }
}