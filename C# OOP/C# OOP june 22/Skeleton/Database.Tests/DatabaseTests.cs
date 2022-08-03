namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database dataBase;

        [SetUp]
        public void SetUp()
        {
            this.dataBase = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            Database testDb = new Database(elementsToAdd);

            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount,
                "Constructor should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[] { 1, 2, 3 };
            Database testDb = new Database(initData);

            int actualCount = testDb.Count;
            int expectedCount = initData.Length;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should return the count of the added elements!");
        }

        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            int actualCount = this.dataBase.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements in the Database!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            foreach (int el in elementsToAdd)
                this.dataBase.Add(el);

            int[] actualData = this.dataBase.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.dataBase.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Add should physically add the elements to the field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Add should change the elements count when adding!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            for (int i = 1; i <= 16; i++)
                this.dataBase.Add(i);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dataBase.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void RemoveShouldRemoveTheLastElementSuccessfullyOnce(int[] startElements)
        {
            foreach (int el in startElements)
                this.dataBase.Add(el);

            this.dataBase.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this.dataBase.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = this.dataBase.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            List<int> initData = new List<int>() { 1, 2, 3 };
            foreach (int el in initData)
                this.dataBase.Add(el);

            for (int i = 0; i < initData.Count; i++)
                this.dataBase.Remove();

            int[] actualData = this.dataBase.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this.dataBase.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount,
                "Remove should decrement the count of the Database!");
        }

        [Test]
        public void RemoveShouldThrowErrorWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dataBase.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] initData)
        {
            foreach (int el in initData)
                this.dataBase.Add(el);

            int[] actualResult = this.dataBase.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult,
                "Fetch should return copy of the existing data!");
        }



        //[TestCase(new int[] { 1 })]
        //[TestCase(new int[] { 4, 18, 17, 5, 3, 1000 })]
        //[TestCase(new int[] { int.MinValue, int.MaxValue, 5 })]
        //[TestCase(new int[0])]
        //public void Constructor_With_Validdata_Should_Pass(int[] parameters)
        //{
        //    Database database = new Database(parameters);
        //    Assert.AreEqual(parameters.Length, database.Count);
        //}

        //[TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, 4)]
        //[TestCase(new int[0], new int[] { int.MinValue, int.MaxValue, 334455 }, 3)]
        //[TestCase(new int[0], new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 16)]
        //public void Add_With_Validdata_Positive_Test(int[] ctorParams, int[] paramsToAdd, int expectedCount)
        //{
        //    Database database = new Database(ctorParams);

        //    for (int i = 0; i < paramsToAdd.Length; i++)
        //    {
        //        database.Add(paramsToAdd[i]);
        //    }

        //    Assert.AreEqual(expectedCount, database.Count);
        //}

        //[TestCase(new int[] { 10, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, 1)]
        //[TestCase(new int[0], new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 1)]
        //public void Add_With_Validdata_Negative_Test(int[] ctorParams, int[] paramsToAdd, int errorParam)
        //{
        //    Database database = new Database(ctorParams);

        //    for (int i = 0; i < paramsToAdd.Length; i++)
        //    {
        //        database.Add(paramsToAdd[i]);
        //    }

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        database.Add(errorParam);
        //    });
        //}

        //[TestCase(new int[] { 10, 3, 5, 10 }, new int[] { 1, 2, 3, 4, 5 }, 3, 6)]
        //[TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, 5, 0)]
        //[TestCase(new int[1] { 1 }, new int[] { 1 }, 1, 1)]
        //public void Remove_With_ValidData_Positive_Test(int[] ctorParams, int[] paramsToAdd, int removeCount, int expectedCount)
        //{
        //    Database database = new Database(ctorParams);

        //    for (int i = 0; i < paramsToAdd.Length; i++)
        //    {
        //        database.Add(paramsToAdd[i]);
        //    }

        //    for (int i = 0; i < removeCount; i++)
        //    {
        //        database.Remove();
        //    }

        //    Assert.AreEqual(expectedCount, database.Count);
        //}

        //[TestCase(new int[] { 10, 3, 5, 10 }, new int[] { 1, 2, 3, 4, 5 })]
        //[TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 })]
        //[TestCase(new int[1] { 1 }, new int[] { 1 })]
        //public void Remove_With_InvalidData_Negative_Test(int[] ctorParams, int[] paramsToAdd)
        //{
        //    Database database = new Database(ctorParams);

        //    for (int i = 0; i < paramsToAdd.Length; i++)
        //    {
        //        database.Add(paramsToAdd[i]);
        //    }

        //    while (database.Count > 0)
        //    {
        //        database.Remove();
        //    }

        //    Assert.Throws<InvalidOperationException>(() =>
        //    {
        //        database.Remove();
        //    });
        //}


        //[TestCase(new int[] { 10, 3, 5, 10 })]
        //[TestCase(new int[0])]
        //[TestCase(new int[1] { 1 })]
        //public void Fetch(int[] ctorParams)
        //{
        //    Database database = new Database(ctorParams);

        //    int[] items = database.Fetch();

        //    Assert.AreEqual(items.Length, database.Count);
        //}



        //[TestCase(new int[] { 10, 3, 5, 10 }, new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 10, 3, 5, 10, 1, 2, 3 })]
        //[TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        //[TestCase(new int[1] { 1 }, new int[] { 1 }, 1, new int[] { 1 })]
        //public void Fetch_Positive(int[] ctorParams, int[] paramsToAdd, int removesCount, int[] expectedArray)
        //{
        //    Database database = new Database(ctorParams);

        //    foreach (var item in paramsToAdd)
        //    {
        //        database.Add(item);
        //    }

        //    for (int i = 0; i < removesCount; i++)
        //    {
        //        database.Remove();
        //    }

        //    int[] actualData = database.Fetch();

        //    CollectionAssert.AreEqual(expectedArray, actualData);
        //}
    }
}
