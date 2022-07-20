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
            List<ITransaction> filteredTransactions = this.transactions.Values
                .Where(x => x.Amount >= lo && x.Amount <= hi)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            return filteredTransactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => transactions.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> sendersNames = transactions.Values
                  .ToList()
                  .Where(x => x.Status == status)
                  .Select(x => x.To)
                  .ToList();
            if (sendersNames.Count == 0)
                throw new InvalidOperationException();

            return sendersNames;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> sendersNames = transactions.Values
                .ToList()
                .Where(x => x.Status == status)
                .Select(x => x.From)
                .ToList();
            // foreach (var (transactionID, currTransaction) in this.transactions)
            // {
            //     if (currTransaction.Status == status)
            //         sendersNames.Add(currTransaction.From);
            // }
            if (sendersNames.Count == 0)
                throw new InvalidOperationException();

            return sendersNames;
        }

        public ITransaction GetById(int id)
       => this.transactions.ContainsKey(id)
            ? this.transactions[id]
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> filteredTransactions = this.transactions.Values
                .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x=> x.Id)
                .ToList();

            if (filteredTransactions.Count == 0)
                throw new InvalidOperationException();

            return filteredTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> filteredTransactions = this.transactions.Values.Where(x => x.To == receiver).OrderByDescending(x => x.Amount).ThenBy(x=> x.Id).ToList();

            if (filteredTransactions.Count == 0)
                throw new InvalidOperationException();

            return filteredTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> filteredTransactions = this.transactions.Values.Where(x => x.From == sender && x.Amount > amount).OrderByDescending(x => x.Amount).ToList();

            if (filteredTransactions.Count == 0)
                throw new InvalidOperationException();

            return filteredTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> filteredTransactions = this.transactions.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount).ToList();

            if (filteredTransactions.Count == 0)
                throw new InvalidOperationException();

            return filteredTransactions;
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
            List<ITransaction> filteredTransactions = this.transactions.Values
                .Where(x => x.Status == status && x.Amount <= amount)
                .OrderByDescending(x=> x.Amount)
                .ToList();

            return filteredTransactions;
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
