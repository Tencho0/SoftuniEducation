namespace T02Chainalysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Transaction
    {
        public Transaction(string sender, string receiver, int amount)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Amount = amount;
        }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public int Amount { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var sender = input[0];
                var receiver = input[1];
                var amount = int.Parse(input[2]);
                var transaction = new Transaction(sender, receiver, amount);
                transactions.Add(transaction);
            }

            var groups = new List<HashSet<string>>();
            foreach (var transaction in transactions)
            {
                var sender = transaction.Sender;
                var receiver = transaction.Receiver;
                var senderGroup = groups.FirstOrDefault(g => g.Contains(sender));
                var receiverGroup = groups.FirstOrDefault(g => g.Contains(receiver));
                if (senderGroup == null && receiverGroup == null)
                {
                    var newGroup = new HashSet<string> { sender, receiver };
                    groups.Add(newGroup);
                }
                else if (senderGroup == null)
                {
                    receiverGroup.Add(sender);
                }
                else if (receiverGroup == null)
                {
                    senderGroup.Add(receiver);
                }
                else if (senderGroup != receiverGroup)
                {
                    senderGroup.UnionWith(receiverGroup);
                    groups.Remove(receiverGroup);
                }
            }

            Console.WriteLine(groups.Count);
        }
    }
}

//You are given a list of Bitcoin transactions, represented as tuples of three elements: (sender, receiver, amount), where sender and receiver are unique Bitcoin addresses, and the amount is a positive integer representing the amount of Bitcoin being transferred. 
//    Your task is to determine the number of groups of Bitcoin addresses that have participated in at least one transaction with each other.
//    In other words, given a transaction between two addresses, those addresses are considered to be in the same group. Two addresses that are indirectly connected through other addresses participating in the transactions are also considered to be in the same group.
//    For example, given the following list of transactions: 
//[('A', 'B', 1), ('B', 'C', 2), ('C', 'D', 3), ('E', 'F', 1), ('F', 'G', 2), ('G', 'H', 3)]
//We have 2 groups of Bitcoin addresses.
//    Input
//    On the first line, you will receive an integer n - representing the number of transactions.
//    On the next n lines, you will receive each transaction in the following format: "{from} {to} {amount}"
//Output
//    The output consists of one number - how many groups are found out of all transactions.
//    Constraints
//    The input will always be in the format described in the Input section.
//    Transactions will be unique.
//    The number of transactions will be in the range [1… 100].
//    The number of groups will be in the range [1… 100].
