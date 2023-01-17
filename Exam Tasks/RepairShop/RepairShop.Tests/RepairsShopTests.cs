using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {


            [TestCase(null)]
            [TestCase("")]
            public void TestForNullOrEmptyGarageName(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 1);
                });
            }

            [TestCase(-1)]
            [TestCase(-2)]
            [TestCase(-100)]
            public void TestForNegativeCountMechanics(int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Garage", mechanicsAvailable);
                });
            }

            //[TestCase("Garage1",0)]
            [TestCase("Garage2", 1)]
            [TestCase("Garage3", 10)]
            public void TestForConstructor(string name, int mechanicsAvailable)
            {
                // Garage garage1 = new Garage("Test",6);
                Garage garage = new Garage(name, mechanicsAvailable);
                string expected = garage.Name;
                string actual = name;

                int expectedCount = garage.MechanicsAvailable;
                int actualCount = mechanicsAvailable;
                Assert.AreEqual(expected, actual);
                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void TestForCount()
            {
                Garage garage = new Garage("Desi", 2);
                Car car = new Car("Desi", 2);
                garage.AddCar(car);
                List<Car> cars = new List<Car>();
                cars.Add(car);

                int expected = garage.CarsInGarage;
                int actual = cars.Count;

                Assert.AreEqual(expected, actual);

            }

            [Test]
            public void TestForEquelCrasAndMechanics()
            {
                Garage garage = new Garage("Desi", 2);
                Car car = new Car("Desi", 2);
                Car car2 = new Car("Desi", 2);
                garage.AddCar(car);
                garage.AddCar(car2);
                Car car3 = new Car("Desi", 2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car3);
                });

            }
            [TestCase("Desi")]
            [TestCase("Veni")]
            public void TestForFixingCar(string model)
            {
                Garage garage = new Garage("Desii", 2);
                Car car = new Car("Desi", 2);
                Car car2 = new Car("Veni", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                int expected = garage.FixCar(model).NumberOfIssues;
                int actual = 0;
                Assert.AreEqual(expected, actual);


            }

            [TestCase(null)]
            public void TestForNullFixingCar(string model)
            {
                Garage garage = new Garage("Desii", 2);
                Car car = new Car(model, 0);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(model);
                });
            }

            [TestCase("Desi")]
            [TestCase("Veni")]
            public void TestForRemovingCar(string model)
            {
                Garage garage = new Garage("Desii", 2);
                Car car = new Car("Desi", 2);
                Car car2 = new Car("Veni", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar(model);
                var fixedcars = garage.RemoveFixedCar();

                int expected = garage.CarsInGarage;

                Assert.That(fixedcars, Is.EqualTo(1));
                Assert.That(expected, Is.EqualTo(1));

            }

            [TestCase("Desi")]
            [TestCase("Veni")]
            public void TestForRemoving0Cars(string model)
            {
                Garage garage = new Garage("Desii", 2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });

            }
            [Test]
            public void TestReport()
            {
                Garage garage = new Garage("Desii", 2);
                Car car = new Car("Desi", 2);
                Car car2 = new Car("Veni", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar("Desi");

                var report = garage.Report();
                Assert.That(report, Is.EqualTo($"There are 1 which are not fixed: Veni."));

            }


        }
    }
}