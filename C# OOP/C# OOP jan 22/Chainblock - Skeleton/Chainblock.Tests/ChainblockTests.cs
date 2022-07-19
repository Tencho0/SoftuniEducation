namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChainblockTests
    {
        private IChainblock chainblock;
        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void AddMethod_Should_Add_Transaction_If_Data_Is_Valid()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Kircho",
                Amount = 250
            };

            chainblock.Add(transaction);
            chainblock.Add(transaction);

            Assert.True(chainblock.Contains(transaction));
            Assert.AreEqual(1, chainblock.Count);
        }
        [Test]
        public void ContainsMethod_Should_Return_True_IfDataIsValid()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Kircho",
                Amount = 250
            };

            ITransaction secondTransaction = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };

            chainblock.Add(transaction);

            Assert.True(chainblock.Contains(transaction));
            Assert.True(chainblock.Contains(transaction.Id));
            Assert.False(chainblock.Contains(secondTransaction));
            Assert.False(chainblock.Contains(secondTransaction.Id));
        }
        [Test]
        public void ChangeTransactionStatus_ShouldChangeStatus_IfDataExist()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };

            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(2, TransactionStatus.Failed);
            ITransaction currTransaction = chainblock.GetById(2);

            //Assert.True(currTransaction.Status == TransactionStatus.Failed);
            Assert.AreEqual(TransactionStatus.Failed, currTransaction.Status);
        }
        [Test]
        public void ChangeTransactionStatus_ShouldThrowException_IfDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull));
        }
        [Test]
        public void RemoveTransactionById_ShouldRemoveTransaction_IfDataIsValid()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };

            chainblock.Add(transaction);
            chainblock.Add(transaction2);

            chainblock.RemoveTransactionById(1);

            Assert.AreEqual(1, chainblock.Count);
        }
        [Test]
        public void RemoveTransactionById_ShouldThrowException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(1));
        }
        [Test]
        public void CheckById_ShouldReturnTransaction_IfIdExist()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };
            chainblock.Add(transaction);
            ITransaction givenTransaction = chainblock.GetById(1);

            Assert.AreEqual(transaction, givenTransaction);
            Assert.AreSame(transaction, givenTransaction);
        }
        [Test]
        public void CheckById_ShouldThrowException_IfIdDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(1));
        }
        [Test]
        public void GetByTransactionStatus_ShouldReturnTheTransaction_IfDataIsValid()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 150
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 1250
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Misho",
                To = "Angel",
                Amount = 1250
            };

            this.chainblock.Add(transaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);

            IEnumerable<ITransaction> returnedTransactions = this.chainblock
                .GetByTransactionStatus(TransactionStatus.Successfull);
            //  ICollection<ITransaction> givenTransactions = new List<ITransaction>();
            //  givenTransactions.Add(transaction);
            //  givenTransactions.Add(transaction2);

            foreach (var item in returnedTransactions)
                Assert.True(item.Status == TransactionStatus.Successfull);

            Assert.True(returnedTransactions.Any(x => x == transaction));
            Assert.True(returnedTransactions.Any(x => x == transaction2));
            Assert.AreEqual(2, returnedTransactions.Count());
            
            // CollectionAssert.AreEqual(new ITransaction[] { transaction, transaction2 }, returnedTransactions);
        }
        [Test]
        public void GetByTransactionStatus_ShouldThrowException_IfDataDoesntValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Successfull));
        }
    }
}
