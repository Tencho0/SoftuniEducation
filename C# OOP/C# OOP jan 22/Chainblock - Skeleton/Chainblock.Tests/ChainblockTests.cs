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
        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnSenders_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 1540
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Grisho",
                To = "Tisho",
                Amount = 2150
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Rumen",
                To = "Gerasim",
                Amount = 1502
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Pavel",
                To = "Anton",
                Amount = 1502
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<string> senders = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToList();

            Assert.AreEqual(3, senders.Count);
            CollectionAssert.AreEqual(new List<string>() { "Misho", "Sasho", "Rumen" }, senders);
        }
        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
        }
        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnReceivers_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 1540
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Grisho",
                To = "Tisho",
                Amount = 2150
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Rumen",
                To = "Gerasim",
                Amount = 1502
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Pavel",
                To = "Anton",
                Amount = 1502
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<string> receivers = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToList();

            Assert.AreEqual(3, receivers.Count);
            CollectionAssert.AreEqual(new List<string>() { "Angel", "Kriso", "Gerasim" }, receivers);
        }
        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnOrderedTransactions_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Misho",
                To = "Angel",
                Amount = 1540
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Grisho",
                To = "Tisho",
                Amount = 2150
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            List<ITransaction> receivers = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            // Assert.AreEqual(3, receivers.Count);
            // Assert.True(receivers.Contains(transaction1));
            // Assert.True(receivers.Contains(transaction2));
            // Assert.True(receivers.Contains(transaction3));
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction3, transaction1, transaction2 }, receivers);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnOrderedSenders_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Pesho",
                To = "Angel",
                Amount = 1540
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Pesho",
                To = "Tisho",
                Amount = 2150
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Aborted,
                From = "Pesho",
                To = "Minka",
                Amount = 21520
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Sashko",
                To = "Kirka",
                Amount = 2520
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Sashko",
                To = "Pesho",
                Amount = 2520
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);

            ICollection<ITransaction> filteredTransactions = chainblock.GetBySenderOrderedByAmountDescending("Pesho").ToList();

            Assert.AreEqual(3, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction4, transaction3, transaction1 }, filteredTransactions);
        }
        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Ivan"));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnOrderedReceivers_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Pesho",
                To = "Angel",
                Amount = 1540
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Minka",
                To = "Angel",
                Amount = 2520
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Aborted,
                From = "Kiril",
                To = "Angel",
                Amount = 21520
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Aborted,
                From = "Demon",
                To = "NEeAngel",
                Amount = 2520
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Sashko",
                To = "Angel",
                Amount = 2520
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);

            ICollection<ITransaction> filteredTransactions = chainblock.GetByReceiverOrderedByAmountThenById("Angel").ToList();

            Assert.AreEqual(4, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction4, transaction3, transaction6, transaction1 }, filteredTransactions);
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowNewException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Ivan"));
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnTransactions_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Pesho",
                To = "Angel",
                Amount = 1500
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Aborted,
                From = "Sasho",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Minka",
                To = "Angel",
                Amount = 2520
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2500
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2501
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            ITransaction transaction7 = new Transaction()
            {
                Id = 7,
                Status = TransactionStatus.Failed,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            ITransaction transaction8 = new Transaction()
            {
                Id = 8,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 5000
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);
            chainblock.Add(transaction7);
            chainblock.Add(transaction8);

            ICollection<ITransaction> filteredTransactions = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 2500).ToList();

            Assert.AreEqual(3, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction4, transaction6, transaction1 }, filteredTransactions);
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection_IfDataIsNotValid()
        {
            Assert.AreEqual(0, chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100).Count());
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnTransactions_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 1500
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Aborted,
                From = "Kriso",
                To = "Kriso",
                Amount = 1520
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Minka",
                To = "Angel",
                Amount = 2520
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2500
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2501
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            ITransaction transaction7 = new Transaction()
            {
                Id = 7,
                Status = TransactionStatus.Failed,
                From = "Ginka",
                To = "Angel",
                Amount = 2502
            };
            ITransaction transaction8 = new Transaction()
            {
                Id = 8,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 5000
            };

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);
            chainblock.Add(transaction7);
            chainblock.Add(transaction8);

            ICollection<ITransaction> filteredTransactions = chainblock.GetBySenderAndMinimumAmountDescending("Ginka", 2500).ToList();

            Assert.AreEqual(3, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction8, transaction7, transaction5 }, filteredTransactions);
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Ivan", 200));
        }
        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnFilteredTransactions_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 1500
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Aborted,
                From = "Ginka",
                To = "Kriso",
                Amount = 1234
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Ginka",
                To = "Angel",
                Amount = 2000
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2500
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };  
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);

            ICollection<ITransaction> filteredTransactions = chainblock.GetByReceiverAndAmountRange("Angel", 2000, 2500).ToList();

            Assert.AreEqual(3, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() { transaction4,transaction6, transaction3}, filteredTransactions);
        }
        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowNewException_IfDataIsNotValid()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Ivan",100, 200));
        }
        [Test]
        public void GetAllInAmountRange_ShouldReturnTransactions_IfDataIsValid()
        {
            ITransaction transaction1 = new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 1500
            };
            ITransaction transaction2 = new Transaction()
            {
                Id = 2,
                Status = TransactionStatus.Aborted,
                From = "Ginka",
                To = "Kriso",
                Amount = 1234
            };
            ITransaction transaction3 = new Transaction()
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Ginka",
                To = "Angel",
                Amount = 2000
            };
            ITransaction transaction4 = new Transaction()
            {
                Id = 4,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            ITransaction transaction5 = new Transaction()
            {
                Id = 5,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2500
            };
            ITransaction transaction6 = new Transaction()
            {
                Id = 6,
                Status = TransactionStatus.Successfull,
                From = "Ginka",
                To = "Angel",
                Amount = 2499
            };
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);
            chainblock.Add(transaction6);

            ICollection<ITransaction> filteredTransactions = chainblock.GetAllInAmountRange(2000, 2500).ToList();

            Assert.AreEqual(4, filteredTransactions.Count);
            CollectionAssert.AreEqual(new List<ITransaction>() {transaction5, transaction4, transaction6, transaction3 }, filteredTransactions);
        }
        [Test]
        public void GetAllInAmountRange_ShouldThrowNewException_IfDataIsNotValid()
        {
            Assert.AreEqual(0, chainblock.GetAllInAmountRange(100, 200).Count());
        }
    }
}
