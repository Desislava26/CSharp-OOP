namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]

        public void TestForConstructor()
        {
            Car car = new Car("Test", "Model", 0.7, 60);
            Assert.That(car.Make.Equals("Test"));
            Assert.That(car.Model.Equals("Model"));
            Assert.That(car.FuelConsumption.Equals(0.7));
            Assert.That(car.FuelCapacity.Equals(60));
            Assert.That(car.FuelAmount.Equals(0));
        }

        [TestCase("", "X5", 6.6, 60)]
        [TestCase(null, "X5", 6.6, 60)]
        [TestCase("Test", "", 6.6, 60)]
        [TestCase("Name", null, 6.6, 60)]
        [TestCase("Test", "X5", -6.6, 0)]
        [TestCase("Test", "X5", 0, 0)]
        [TestCase("Test", "X5", 2, -11)]
        public void TestForNullOrEmptyOrNegativeInput(string make, string model, double fuelConsm, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsm, fuelCapacity);

            });
     
           
        }

      
        [TestCase("Test", "X5", 5, 10, -1)]
        [TestCase("Test", "X5", 5, 10, 0)]
        public void TestForRefuelNegative(string make, string model, double fuelConsm, double fuelCapacity, double refuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsm, fuelCapacity);
                car.Refuel(refuel);

            });

        }

        [Test]

        public void TestForEmptyConstructorShouldSetFuelAmountTo0()
        {
            Car car = new Car("Test", "Model", 0.7, 50);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(60)]
        [TestCase(10)]
        public void TestForRefuelMethodShouldIncreaseFuelAmount(double fuel)
        {
            Car car = new Car("Test", "Micra", 0.7, 60);
            double fuelBefore = car.FuelAmount;
            car.Refuel(fuel);

            Assert.That(car.FuelAmount, Is.EqualTo(fuel + fuelBefore));
        }

        [Test]
        public void TestForRefuelMethodShouldReturnAmountEqualToFuelCapacity()
        {
            Car car = new Car("Test", "Micra", 0.7, 60);
            car.Refuel(70);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [TestCase("Test", "X5", 5, 50, 15)]
        [TestCase("Test", "X5", 5, 30, 5)]
        [TestCase("Test", "X5", 5, 30, 50)]
        public void TestForDrive(string make, string model, double fuelConsm, double fuelCapacity, double distance)
        {
            var car = new Car(make, model, fuelConsm, fuelCapacity);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            car.Refuel(20);
            var actual = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
           

            Assert.AreEqual(car.FuelAmount, actual);
              
        }
        [TestCase("Test", "X5", 5, 50, 100)]
        [TestCase("Test", "X5", 5, 30, 200)]
        [TestCase("Test", "X5", 5, 30, 300)]
        public void TestForDriveLongerDistance(string make, string model, double fuelConsm, double fuelCapacity, double distance)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var car = new Car(make, model, fuelConsm, fuelCapacity);
                car.Drive(distance);

            });

        }

    }
}