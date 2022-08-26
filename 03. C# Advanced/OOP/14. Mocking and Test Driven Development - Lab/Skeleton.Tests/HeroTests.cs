using NUnit.Framework;

namespace Skeleton.Tests
{
    public class HeroTests
    {
        private Axe axe;
        private Dummy dummy;
        private Hero hero;
        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 44);
            hero = new Hero("Pesho", axe);
        }
        [Test]
        public void ConstructorShouldInitializeHeroCorrectly()
        {
            Assert.That(hero.Name, Is.EqualTo("Pesho"));
            Assert.That(hero.Experience, Is.EqualTo(0));
            Assert.That(hero.Weapon, !Is.Null);
        }

        [Test]
        public void AttackShouldDecreaseDummyHpAndInceaseHeroExperianceByDummyXp()
        {
            hero.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(0));
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
            Assert.That(hero.Experience, Is.EqualTo(44));
        }
    }
}
