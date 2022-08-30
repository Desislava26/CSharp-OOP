namespace FightingArena.Tests
{
    using NUnit.Framework;
    using FightingArena;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestForValidName()
        {
            string expectedName = "Desi";
            Warrior warrior = new Warrior(expectedName, 50, 50);
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);

        }
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("      ")]
        public void TestForInvalidName(string expectedName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(expectedName, 50, 50);
            });

        }

        [TestCase(1)]
        [TestCase(100)]
        [TestCase(50)]
        public void TestForValidDamage(int expectedDamage)
        {
            //int expectedDamage = 50;
            Warrior warrior = new Warrior("Desi", expectedDamage, 50);
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);

        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(-1)]
        public void TestForInvalidDamage(int expectedDamage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Desi", expectedDamage, 50);
            });
        }

        [TestCase(1)]
        [TestCase(100)]
        [TestCase(50)]
        public void TestForValidHP(int expectedHP)
        {
            //int expectedDamage = 50;
            Warrior warrior = new Warrior("Desi", 50, expectedHP);
            int actualDamage = warrior.HP;
            Assert.AreEqual(expectedHP, actualDamage);

        }
        [TestCase(-3)]
        [TestCase(-100)]
        [TestCase(-1)]
        public void TestForInvalidHP(int expectedHP)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Desi", 50, expectedHP);
            });
        }

        [TestCase(29)]
        [TestCase(20)]
        public void WarriorCannotAttackUnder30HP(int expextHp)
        {
            Warrior warrior1 = new Warrior("Desi", 50, expextHp);
            Warrior warrior2 = new Warrior("Desi", 50, 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [TestCase(70,50)]
        [TestCase(60,55)]
        [TestCase(60, 60)]
        public void WarriorCanAttackUpper30HP(int attackHp, int defenderDamage)
        {
            Warrior warrior1 = new Warrior("Desi", 50, attackHp);
            Warrior warrior2 = new Warrior("Desi", defenderDamage, 55);
            warrior1.Attack(warrior2);
            int expected = warrior1.HP;
            int actual = attackHp- defenderDamage;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(20)]
        [TestCase(10)]
        public void WarriorCannotAttackOthersWith30HP(int expextHp)
        {
            Warrior warrior1 = new Warrior("Desi", 50, 50);
            Warrior warrior2 = new Warrior("Desi", 50, expextHp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [TestCase(50,60)]
        [TestCase(50,51)]
        public void WarriorCannotAttackStrongerEnemy(int attackHp, int defendDamage)
        {
            Warrior warrior1 = new Warrior("Desi", 50, attackHp);
            Warrior warrior2 = new Warrior("Desi", defendDamage, 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

    }
}