namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]

        public void TestConstructorAndCount()
        {
            IReadOnlyCollection<Warrior> list = new List<Warrior>();
            Arena arena = new Arena();
            Assert.AreEqual(list, arena.Warriors);

            Assert.AreEqual(list.Count, arena.Count);
        }

        [Test]
        public void TestEnrollAddsWarriorsToTheArena()
        {
            Arena arena = new Arena();
            Warrior pesho = new Warrior("Pesho", 30, 100);
            Warrior gosho = new Warrior("Gosho", 35, 85);

            arena.Enroll(pesho);
            arena.Enroll(gosho);

            List<Warrior> actualCollection = arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>()
            {
                pesho,
                gosho
            };

            CollectionAssert.AreEqual(expectedCollection, actualCollection,
                "Warriors collection getter should return enrolled warriors!");
        }
        [Test]

        public void TestEnrollЕxception()
        {
            Arena arena = new Arena();
            List<Warrior> list = new List<Warrior>();
            Warrior warrior1 = new Warrior("Desi", 50, 50);
            Warrior warrior2 = new Warrior("Desi", 50, 50);
            list.Add(warrior1);
            list.Add(warrior2);
            List<Warrior> list2 = new List<Warrior>();

            foreach (Warrior warrior in list)
            {
                if (list2.Any(w => w.Name == warrior.Name))
                {
                    Assert.Throws<InvalidOperationException>(() =>
                    {
                        arena.Enroll(warrior);
                    });

                }
                else
                {
                    list2.Add(warrior);
                    arena.Enroll(warrior);
                }



            }


        }

        [TestCase(null, "")]
        [TestCase("  ", null)]
        public void TestFightNull(string attackerName, string defenderName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior1 = new Warrior(attackerName, 50, 50);
                Warrior warrior2 = new Warrior(defenderName, 50, 50);
            });


        }

        [Test]
        public void TestFightSucsess()
        {
            Warrior warrior1 = new Warrior("Desi", 40, 100);
            Warrior warrior2 = new Warrior("Veni", 55, 100);
            Arena arena = new Arena();

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight("Desi", "Veni");

            int actualAttackerHp = warrior1.HP;
            int expectedAttackerHp = 100 - warrior2.Damage;

            int actualDefenderHp = warrior1.HP;
            int expectedDefenderHp = 100 - warrior2.Damage;

        }

        [Test]
        public void TestAttackerAttackInvalidDefender()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Desi", 40, 100);
            Warrior warrior2 = new Warrior("Veni", 55, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Desi", "Invalid");
            });



        }
        [Test]
        public void CountShouldReturnZeroOnEmptyArena()
        {
            Arena arena = new Arena();
            int actualCount = arena.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return zero when there are no enrolled Warriors!");
        }

        [Test]
        public void TestIfWarriorsCollectionIsEncapsulatedProperly()
        {
            string actualType = typeof(Arena)
                .GetProperties()
                .First(pi => pi.Name == "Warriors")
                .PropertyType
                .Name;
            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectedType, actualType,
                "Property for the enrolled Warriors should be of type IReadOnlyCollection<Warrior>!");
        }



    }
}
