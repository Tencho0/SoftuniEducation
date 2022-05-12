namespace Database.Tests
{
    using NUnit.Framework;

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
        [TestCase(new int[0], new int[] { int.MinValue, int.MaxValue, 334455}, 3)]
        public void Add_With_Validdata_Should_Pass(int[] ctorParams, int[] paramsToAdd, int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
    }
}
