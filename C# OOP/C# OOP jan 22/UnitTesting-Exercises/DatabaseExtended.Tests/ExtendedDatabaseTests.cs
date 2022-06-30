namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
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
        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_ShouldThrow_InvalidOperationException_With_InvalidData_Negative_Test
            (Person[] peopleClor,
            Person[] peopleAdd,
            Person inPerson)
        {
            Database database = new Database(peopleClor);

            foreach (var item in peopleAdd)
            {
                database.Add(item);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(inPerson));
        }
        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_Should_Remove_With_Invalid_Data
            (Person[] peopleClor,
            Person[] peopleAdd,
            int peopleToRemove,
            int expectedPeopleCount)
        {
            Database database = new Database(peopleClor);

            foreach (var item in peopleAdd)
                database.Add(item);

            for (int i = 0; i < peopleToRemove; i++)
                database.Remove();
            
            Assert.AreEqual(expectedPeopleCount, database.Count);

        }
        public static IEnumerable<TestCaseData> TestCaseRemoveData()
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
                     },
                     3,
                     3)
            };

            foreach (var item in testCases)
                yield return item;
        }
        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                 new TestCaseData(
                    new Person[]
                     {
                         new Person(1, "kircho"),
                         new Person(2, "ivcho"),
                         new Person(3, "mircho"),
                         new Person(4, "mircho2"),
                         new Person(5, "mircho3"),
                         new Person(6, "mircho4"),
                         new Person(7, "mircho5"),
                         new Person(8, "mircho6"),
                         new Person(9, "mircho7"),
                         new Person(10, "mircho8"),
                         new Person(11, "mircho9"),
                         new Person(12, "mircho10"),
                         new Person(13, "mircho11"),
                     },
                    new Person[]
                     {
                         new Person(14, "kircho2"),
                         new Person(15, "ivcho2"),
                         new Person(16, "mircho12"),
                     },
                    new Person(17, "kircho33")),
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
                    new Person(4, "kircho")),
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
                    new Person(3, "kircho1111"))
            };

            foreach (var item in testCases)
                yield return item;
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