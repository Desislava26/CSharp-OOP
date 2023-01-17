namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void TestForNullOrEmptyAquriumName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 10);
            });
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-100)]
        public void TestForNegativeCountCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Desi", capacity);
            });
        }

        [TestCase("Garage2", 1)]
        [TestCase("Garage3", 10)]
        public void TestForConstructor(string name, int capacity)
        {
            // Garage garage1 = new Garage("Test",6);
            Aquarium aqua = new Aquarium(name, capacity);
            string expected = aqua.Name;
            string actual = name;

            int expectedCount = aqua.Capacity;
            int actualCount = capacity;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestForCount()
        {
            Aquarium aqua = new Aquarium("Desi", 2);
            Fish fish = new Fish("Desi");
            aqua.Add(fish);
            List<Fish> fishs = new List<Fish>();
            fishs.Add(fish);

            int expected = aqua.Count;
            int actual = fishs.Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestForInvalidAdding()
        {
            Aquarium aqua = new Aquarium("Desi", 1);
            Fish fish = new Fish("Desi");
            aqua.Add(fish);
            Fish fish2 = new Fish("Desi");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.Add(fish2);
            });
            
        }

        [TestCase("Desi")]
        [TestCase("Veni")]
        public void TestForRemovingFish(string model)
        {
            Aquarium aqua = new Aquarium("Desii", 2);
            Fish fish = new Fish("Desi");
            Fish fish2 = new Fish("Veni");
            aqua.Add(fish);
            aqua.Add(fish2);

            aqua.RemoveFish(model);

            int expected = aqua.Count;

           
            Assert.That(expected, Is.EqualTo(1));

        }

        
        [TestCase(null)]
        public void TestForRemovingNullFish(string model)
        {
            Aquarium aqua = new Aquarium("Desii", 2);
            Fish fish = new Fish("Desi");
            Fish fish2 = new Fish("Veni");
            aqua.Add(fish);
            aqua.Add(fish2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.RemoveFish(model);
            });
            
           

        }
        [TestCase(null)]
        public void TestForSellingNullFish(string model)
        {
            Aquarium aqua = new Aquarium("Desii", 2);
            Fish fish = new Fish("Desi");
            Fish fish2 = new Fish("Veni");
            aqua.Add(fish);
            aqua.Add(fish2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.SellFish(model);
            });



        }


        [TestCase("Desi")]
       
        public void TestForSellingFish(string model)
        {
            Aquarium aqua = new Aquarium("Desii", 2);
            Fish fish = new Fish("Desi");
            Fish fish2 = new Fish("Veni");
            aqua.Add(fish);
            aqua.Add(fish2);

            aqua.SellFish(model);
            bool expected = fish.Available;
            bool actual = false;


            Assert.That(expected== actual);

        }
        [Test]
        public void TestForReport()
        {
            Aquarium aqua = new Aquarium("Desii", 2);
            Fish fish = new Fish("Desi");
            Fish fish2 = new Fish("Veni");
            aqua.Add(fish);
            aqua.Add(fish2);

            var report = aqua.Report();
            Assert.That(report, Is.EqualTo($"Fish available at Desii: Desi, Veni"));
        }



        }
    }
