using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void IfAttacked_LoosesHealth()
        {
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(9));
        }
        [Test]
        public void DeadDummy_IfAttacked_ThrowsException()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);
            Assert.That(() => { axe.Attack(dummy); }, Throws.InvalidOperationException);
        }
        [Test]
        public void DeadDummy_CanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
        }
        [Test]
        public void AliveDummy_CanNotGiveXP_ThrowsException()
        {
            Dummy dummy = new Dummy(10, 10);
            Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException);
        }
    }
}