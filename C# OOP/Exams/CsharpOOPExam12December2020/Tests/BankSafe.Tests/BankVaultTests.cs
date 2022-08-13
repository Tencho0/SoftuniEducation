using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        public void AddItemMethod_ShouldThrowException_Celldoesntexists_InvalidData()
        {
            Assert.Throws<ArgumentException>(
                () => bankVault.AddItem("CSG23", new Item("pesho", "mndasd2414"))
                , "Cell doesn't exists!");
        }

        [Test]
        public void AddItemMethod_ShouldThrowException_CellIsAlreadyTaken_InvalidData()
        {
            bankVault.AddItem("A1", new Item("pesho", "mndasd2414"));

            Assert.Throws<ArgumentException>(
             () => bankVault.AddItem("A1", new Item("pesho", "mndasd2414"))
             , "Cell is already taken!");
        }
        [Test]
        public void AddItemMethod_ShouldThrowException_ItemIsAlreadyInCell_InvalidData()
        {
            bankVault.AddItem("A1", new Item("pesho", "mndasd2414"));

            Assert.Throws<InvalidOperationException>(
             () => bankVault.AddItem("A2", new Item("pesho", "mndasd2414"))
             , "Item is already in cell!");
        }
        [Test]
        public void AddItemMethod_ShouldAddItem_ValidData()
        {
            var item = new Item("pesho", "mndasd2414");
            var result = bankVault.AddItem("A1", item);
            var expectedResult = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(expectedResult, result);
            Assert.True(bankVault.VaultCells["A1"] == item);
        }
        [Test]
        public void RemoveMethod_ShouldThrowExpection_CellDoesntExists_InvalidData()
        {
            Assert.Throws<ArgumentException>(
                () => bankVault.RemoveItem("A2", new Item("pesho", "sda2"))
                , "Cell doesn't exists!");
        }
        [Test]
        public void RemoveMethod_ShouldThrowException_ItemInThatCellDoesntExists_InvalidData()
        {
            var item = new Item("pesho", "mndasd2414");
            bankVault.AddItem("A1", new Item("pesho", "mndasd2414"));
            Assert.Throws<ArgumentException>(
             () => bankVault.AddItem("A1", new Item("misho", "dsadas4"))
             , "Item in that cell doesn't exists!");
        }
        [Test]
        public void RemoveMethod_ShouldRemoveItem_ValidData()
        {
            var item = new Item("pesho", "mndasd2414");
            bankVault.AddItem("A1", item);
            var result = bankVault.RemoveItem("A1", item);
            var expectedResult = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expectedResult, result);
        }
    }
}