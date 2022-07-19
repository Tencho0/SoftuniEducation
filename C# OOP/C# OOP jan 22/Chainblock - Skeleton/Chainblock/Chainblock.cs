namespace Chainblock
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;
        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }
        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactions.ContainsKey(tx.Id))
            {
                return;
            }
            this.transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }
            this.transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        => this.transactions.ContainsKey(tx.Id);
        public bool Contains(int id)
            => this.transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction GetById(int id)
       => this.transactions.ContainsKey(id)
            ? this.transactions[id]
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
        //   if (!this.transactions.Any(x => x.Value.Status == status))
        //       throw new InvalidOperationException();

            ITransaction[] filteredTransactions = this.transactions.Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .ToArray();

            if (!filteredTransactions.Any())
                throw new InvalidOperationException();

            return filteredTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.transactions.ContainsKey(id))
                throw new InvalidOperationException();

            this.transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
