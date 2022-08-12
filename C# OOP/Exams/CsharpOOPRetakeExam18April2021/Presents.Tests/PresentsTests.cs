namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void TestConstructor()
        {
            Bag bag = new Bag();
            Assert.AreEqual(0, bag.GetPresents().Count);
        }
        [Test]
        public void CreateMethod_ShouldCreate_ValidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);

            var result = bag.Create(present);
            var expectedResult = $"Successfully added present {present.Name}.";

            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void CreateMethod_ShouldThrowExpection_NullPresent_InvalidData()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null), "Present is null");
        }
        [Test]
        public void CreateMethod_ShouldThrowExpection_PresentAlreadyExists_InvalidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present), "This present already exists!");
        }
        [Test]
        public void RemoveMethod_ShouldRemove_ValidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);

            bag.Create(present);
            var result = bag.Remove(present);
            var result2 = bag.Remove(present);

            Assert.True(result);
            Assert.True(!result2);
        }

        [Test]
        public void GetPresentWithLeastMagicMethod_ShouldReturnPresent_ValidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);
            Present present2 = new Present("podaruk2", 30);
            Present present3 = new Present("podaruk3", 25);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            var returnedPresent = bag.GetPresentWithLeastMagic();

            Assert.AreSame(present, returnedPresent);
        }
        [Test]
        public void GetPresentMethod_ShouldReturnPresent_ValidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);
            Present present2 = new Present("golqm podaruk", 30);
            Present present3 = new Present("maluk podaruk", 25);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            var returnedPresent = bag.GetPresent("podaruk");

            Assert.AreSame(present, returnedPresent);
        }
        [Test]
        public void GetPresentsMethod_ShouldReturnPresentsAsReadOnlyCollection_ValidData()
        {
            Bag bag = new Bag();
            Present present = new Present("podaruk", 20);
            Present present2 = new Present("golqm podaruk", 30);
            Present present3 = new Present("maluk podaruk", 25);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            var returnedPresent = bag.GetPresents();

            //Assert.True(returnedPresent.GetType().Name == nameof(IReadOnlyCollection<Present>));
            Assert.AreEqual(3, returnedPresent.Count);
            Assert.True(returnedPresent.Any(x => x.Name == present.Name && x.Magic == present.Magic));
            Assert.True(returnedPresent.Any(x => x.Name == present2.Name && x.Magic == present2.Magic));
            Assert.True(returnedPresent.Any(x => x.Name == present3.Name && x.Magic == present3.Magic));
        }
    }
}
