using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ConstuctorWorksCorrectly()
        {
            Shop shop = new Shop(0);
            Assert.That(shop.Capacity == 0);
            Assert.That(shop.Count == 0);
        }
        [Test]
        public void CapacityShouldThrowExceptionIfInputIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => { Shop shop = new Shop(-1); });
        }
        [Test]
        public void AddShouldThrowExceptionIfThePhoneAlreadyExists()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.Throws<InvalidOperationException>(() => { shop.Add(new Smartphone("Samsung", 100)); });
        }
        [Test]
        public void AddShouldThrowExceptionIfTheShopIsFull()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.Throws<InvalidOperationException>(() => { shop.Add(new Smartphone("IPhone", 100)); });
        }
        [Test]
        public void AddShouldAddThePhoneToTheListIfTheInputIsCorrect()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.That(shop.Count == 1);
        }
        [Test]
        public void RemoveShouldThrowExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(0);
            Assert.Throws<InvalidOperationException>(() => { shop.Remove("IPhone"); });
        }
        [Test]
        public void RemoveShouldRemoveThePhoneIfItExists()
        { 
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 100));
            shop.Remove("Samsung");
            Assert.That(shop.Count == 0);
        }
        [Test]
        public void TestPhoneShouldThrowExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(1); 
            shop.Add(new Smartphone("Samsung", 100)); 
            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone("IPhone", 10); });
        }
        [Test]
        public void TestPhoneShouldThrowExceptionIfTheCurrentBatteryIsLowerThanTheUsage()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 5)); 
            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone("Samsung", 10); });
        }
        [Test]
        public void TestPhoneShouldDecreaseThePhoneBatteryIfTheInputIsCorrect() 
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Samsung", 100);
            shop.Add(smartphone);
            shop.TestPhone("Samsung", 10);
            Assert.That(smartphone.CurrentBateryCharge == 90);
        }
        [Test]
        public void ChargePhoneShouldThrowExceptionIfThePhoneDoesNotExist()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 10));
            Assert.Throws<InvalidOperationException>(() => { shop.ChargePhone("IPhone"); });
        }
        [Test]
        public void ChargePhoneShouldIncreaseThePhoneBatteryIfTheInputIsCorrect()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Samsung", 100);
            shop.Add(smartphone);
            shop.TestPhone("Samsung", 50);
            shop.ChargePhone("Samsung");
            Assert.That(smartphone.CurrentBateryCharge == 100);
        }
    }
}