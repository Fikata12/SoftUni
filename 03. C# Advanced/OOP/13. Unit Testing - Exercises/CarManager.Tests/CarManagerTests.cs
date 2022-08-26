namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private double fuelAmount;
        private Car car;
        [SetUp]
        public void SetUp()
        {
            make = "Make";
            model = "Model";
            fuelConsumption = 1;
            fuelCapacity = 80;
            fuelAmount = 0;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorsShouldSetTheValuesOfThePropsCorrectlyAndTheirGettersShouldReturnItCorrectly()
        {
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.EqualTo(fuelAmount));
        }

        [TestCase("")]
        [TestCase(null)]
        public void MakeShouldThrowExceptionWhenInputDataIsNullOrEmpty(string inputData)
        {
            make = inputData;
            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }

        [TestCase("")]
        [TestCase(null)]
        public void ModelShouldThrowExceptionWhenInputDataIsNullOrEmpty(string inputData)
        {
            model = inputData;
            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionShouldThrowExceptionWhenInputDataIsZeroOrNegative(double inputData)
        {
            fuelConsumption = inputData;
            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityShouldThrowExceptionWhenInputDataIsZeroOrNegative(double inputData)
        {
            fuelCapacity = inputData;
            Assert.Throws<ArgumentException>(() => { car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionWhenInputDataIsZeroOrNegative(double inputData)
        {
            Assert.Throws<ArgumentException>(() => { car.Refuel(inputData); });
        }

        [TestCase(20)]
        [TestCase(90)]
        public void RefuelShoudChangeFuelAmountProperlyIfInputDataIsCorrect(double inputData)
        {
            car.Refuel(inputData);
            if (inputData == 20)
            {
                Assert.That(car.FuelAmount == 20);
            }
            else
            {
                Assert.That(car.FuelAmount == 80);
            }
        }

        [TestCase(80)]
        public void DriveShouldThrowExceptionIfFuelAmountIsLowerThanInputData(double inputData)
        {
            Assert.Throws<InvalidOperationException>(() => { car.Drive(inputData); });
        }

        [TestCase(80)]
        public void DriveShoulDecreseFuelAmountIfFuelAmountIsHigherThanInputData(double inputData)
        {
            car.Refuel(80);
            car.Drive(inputData);
            Assert.That(car.FuelAmount == 79.2);
        }

    }
}