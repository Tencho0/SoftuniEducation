namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseSourceData")]
        public void Constructor_Should_Create_Database_Positive_Test(Person[] people, int expectedCount)
        {
            Database database = new Database(people);
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void Add_Should_Create_Add_Positive_Test
            (Person[] peopleClor,
            Person[] peopleAdd,
            int expectedCount)
        {
            Database database = new Database(peopleClor);
            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }
            Assert.AreEqual(expectedCount, database.Count);
        }
        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                 new TestCaseData(
                    new Person[]
                     {
                         new Person(1, "kircho"),
                         new Person(2, "ivcho"),
                         new Person(3, "mircho"),
                     },
                    new Person[]
                     {
                         new Person(4, "kircho2"),
                         new Person(5, "ivcho2"),
                         new Person(6, "mircho2"),
                     }, 6),
                new TestCaseData(
                    new Person[]
                     {
                     },
                    new Person[]
                     {
                         new Person(1, "kircho"),
                         new Person(2, "ivcho"),
                         new Person(3, "mircho"),
                     },
                    3)
            };

            foreach (var item in testCases)
                yield return item;
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Person[]
                     {
                         new Person(1, "kircho"),
                         new Person(2, "ivcho"),
                         new Person(3, "mircho"),
                     },
                     3),
                new TestCaseData(new Person[]
                     {
                     },
                     0)
            };

            foreach (var item in testCases)
                yield return item;
        }
    }
}