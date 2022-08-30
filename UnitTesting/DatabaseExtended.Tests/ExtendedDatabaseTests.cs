namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
           
        }


        [Test]
        public void TestForSucsessfullyCreatingDatabase()
        {
            Person per1 = new Person(123456789, "User1");
            Person per2 = new Person(123456788, "User2");
            Person per3 = new Person(123456787, "User3");
            Person[] people = { per1, per2, per3 };
            Database basing = new Database(people);
           

            Assert.AreEqual(3, basing.Count);
           


        }

        [Test]
        public void TestForUsersWithUsenameTheSame()
        {
            Person per1 = new Person(123456789, "User1");
            Person per2 = new Person(123456788, "User1");
            Person per3 = new Person(123456787, "User3");
            Person[] people = { per1, per2, per3 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database basing = new Database(people);

            });


        }

        [Test]
        public void TestForUsersWithEgnTheSame()
        {
            Person per1 = new Person(123456789, "User1");
            Person per2 = new Person(123456789, "User2");
            Person per3 = new Person(123456787, "User3");
            Person[] people = { per1, per2, per3 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database basing = new Database(people);

            });


        }

        [Test]
        public void TestForAddingMoreThan16()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                Person[] listing = new Person[17];
                Database basing = new Database(listing);
                

            });
            


        }
        [Test]
        public void TestForAddingTheSameUsernameOrEgn()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] people = { };
                int count = 0;
                for (int i = 0; i <= 5; i++)
                {
                    count++;
                    Person per = new Person(12345678+count, "User"+count);
                    this.database.Add(per);
                }
                Person person = new Person(12345670, "User" + count);
                this.database.Add(person);


            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] people = { };
                int count = 0;
                for (int i = 0; i <= 5; i++)
                {
                    count++;
                    Person per = new Person(12345678 + count, "User" + count);
                    this.database.Add(per);
                }
                Person person = new Person(12345678 + count, "Desi");
                this.database.Add(person);


            });



        }

        [TestCase(null)]
        [TestCase("")]
        public void TestForNullOrEmptyFindingUserName(string name)
        {
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Person[] people = { };
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    count++;
                    Person per = new Person(12345678 + count, "User" + count);
                    this.database.Add(per);
                }
                this.database.FindByUsername(name);
            });




        }

        [TestCase("Desi")]
        [TestCase("Veni")]
        public void TestForNotFindingUserName(string name)
        {
            Person[] people = { };
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                count++;
                Person per = new Person(12345678 + count, "User" + count);
                this.database.Add(per);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername(name);
            });




        }

        [TestCase("User1")]
        [TestCase("User2")]
        public void TestForFindingUserName(string name)
        {
            Person per1 = new Person(123456789, "User1");
            Person per2 = new Person(123456788, "User2");
            Person per3 = new Person(123456787, "User3");
            Person[] people = { per1, per2, per3 };
            Database basing = new Database(people);
            Person returned = basing.FindByUsername(name);
            Assert.That(returned.UserName == name);


        }


        
        [Test]
        public void TestForRemovingWith0Elements()
        {
           
            Person[] people = {};
            Database basing = new Database(people);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });

        }


        [Test]
        public void TestForRemovingElements()
        {
            Person per1 = new Person(123456789, "User1");
            Person per2 = new Person(123456788, "User2");
            Person per3 = new Person(123456787, "User3");
            Person[] people = { per1, per2, per3 };
            Database basing = new Database(people);
            var actual = basing.Count - 1;
            basing.Remove();
            Assert.AreEqual(basing.Count, actual);

        }

        [TestCase(-123456789)]
        public void TestForFindingByNegativeId(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person per1 = new Person(123456789, "User1");
                Person per2 = new Person(123456788, "User2");
                Person per3 = new Person(123456787, "User3");
                Person[] people = { per1, per2, per3 };
                Database basing = new Database(people);
                basing.FindById(id);
            });


        }
        [TestCase(123456780)]
        public void TestForNotFindingById(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person per1 = new Person(123456789, "User1");
                Person per2 = new Person(123456788, "User2");
                Person per3 = new Person(123456787, "User3");
                Person[] people = { per1, per2, per3 };
                Database basing = new Database(people);
                basing.FindById(id);
            });


        }
        [TestCase(123456789)]
        public void TestForFindingById(long id)
        {
           
                Person per1 = new Person(123456789, "User1");
                Person per2 = new Person(123456788, "User2");
                Person per3 = new Person(123456787, "User3");
                Person[] people = { per1, per2, per3 };
                Database basing = new Database(people);
               Person expected =  basing.FindById(id);

            Assert.That(expected.Id == 123456789);
           


        }

        

    }
}