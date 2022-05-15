namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseData("TestCaseSourceData")]
        public void Constructor_Should_Create_Database_Positive_Test(Person[] people, int expectedCount)
        {
            Database database = new Database(people);
            Assert.AreEqual(expectedCount, database.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            yield return 
                new TestCaseData(new Person[]
            {
                new Person(1, "kircho"), 
                new Person(2, "ivcho"),
                new Person(3, "mircho")
            }, 3);
        }
    }
}