namespace Chainblock
{
    using Contracts;
    public class Transaction : ITransaction
    {
        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public override bool Equals(object obj)
        {
            ITransaction transaction = obj as Transaction;

            return this.Id == transaction.Id
                && this.Status == transaction.Status
                && this.From == transaction.From
                && this.To == transaction.To
                && this.Amount == transaction.Amount;
        }
    }
}
