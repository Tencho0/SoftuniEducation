namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    public class ChainblockTests
    {
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

            IChainblock chainblock = new Chainblock();
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

            IChainblock chainblock = new Chainblock();
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
            IChainblock chainblock = new Chainblock();
            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(2, TransactionStatus.Failed);
            ITransaction currTransaction = chainblock.GetById(2);

            //Assert.True(currTransaction.Status == TransactionStatus.Failed);
            Assert.AreEqual(TransactionStatus.Failed, currTransaction.Status);
        }
    }
}
