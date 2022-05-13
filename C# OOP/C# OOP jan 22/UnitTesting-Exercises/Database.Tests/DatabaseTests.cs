namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 4, 18, 17, 5, 3, 1000 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue, 5 })]
        [TestCase(new int[0])]
        public void Constructor_With_Validdata_Should_Pass(int[] parameters)
        {
            Database database = new Database(parameters);
            Assert.AreEqual(parameters.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, 4)]
        [TestCase(new int[0], new int[] { int.MinValue, int.MaxValue, 334455 }, 3)]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 16)]
        public void Add_With_Validdata_Positive_Test(int[] ctorParams, int[] paramsToAdd, int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[] { 10, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, 1)]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 1)]
        public void Add_With_Validdata_Negative_Test(int[] ctorParams, int[] paramsToAdd, int errorParam)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(errorParam);
            });
        }

        [TestCase(new int[] { 10, 3, 5, 10 }, new int[] { 1, 2, 3, 4, 5 }, 3, 5)]
        [TestCase(new int[0], new int[] { 1, 2, 3, 4, 5 }, 5, 0)]
        [TestCase(new int[1] {1}, new int[] { 1}, 1, 1) ]
        public void Remove_With_ValidData_Positive_Test(int[] ctorParams, int[] paramsToAdd, int removeCount, int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
    }
}
