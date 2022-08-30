namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {

            this.db = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_For_16_Integers(int[] data)
        {
            Database testDb = new Database(data);
            int[] expect = testDb.Fetch();
            int[] actual = data;

            int expectCount = testDb.Count;
            int actualCount = actual.Length;

            CollectionAssert.AreEqual(expect, actual);
            Assert.AreEqual(expectCount, actualCount);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void Test_For_Not16_Integers(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");


        }


        [Test]
        public void Test_CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements!");
        }

        [Test]
        public void Test_CountMustReturnZeroWhenNoElements()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements in the Database!");
        }


        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_AddShouldAddLessThan16Elements(int[] elementsToAdd)
        {

            foreach (int el in elementsToAdd)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Add should physically add the elements to the field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Add should change the elements count when adding!");
        }

        [Test]
        public void Test_AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {

            for (int i = 1; i <= 16; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void Test_RemoveShouldRemoveTheLastElementSuccessfullyOnce(int[] startElements)
        {
         
            foreach (int el in startElements)
            {
                this.db.Add(el);
            }

            this.db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this.db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void Test_RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (int el in initData)
            {
                this.db.Add(el);
            }

            for (int i = 0; i < initData.Count; i++)
            {
                this.db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this.db.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void Test_RemoveShouldThrowErrorWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_FetchShouldReturnCopyArray(int[] initData)
        {
           
            foreach (int el in initData)
            {
                this.db.Add(el);
            }

            int[] actualResult = this.db.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Fetch should return copy of the existing data!");

        }
    }
}
