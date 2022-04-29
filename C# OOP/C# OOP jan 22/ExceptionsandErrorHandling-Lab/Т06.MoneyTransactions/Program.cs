using System;
using System.Collections.Generic;
using System.Linq;

namespace Т06.MoneyTransactions
{
    internal class Program
    {
        static Dictionary<int, double> accounts;
        static void Main(string[] args)
        {
            string[] givenAccounts = Console.ReadLine()
                .Split(',');

            accounts = new Dictionary<int, double>();
            foreach (var item in givenAccounts)
            {
                double[] acc = item
                .Split('-')
                .Select(double.Parse)
                .ToArray();

                int accNum = (int)acc[0];
                double money = acc[1];

                accounts.Add(accNum, money);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                int accountNumber = int.Parse(givenCmd[1]);
                double sum = double.Parse(givenCmd[2]);

                try
                {
                    DepositOrWithdraw(action, accountNumber, sum);
                    Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                command = Console.ReadLine();
            }
        }
        public static void DepositOrWithdraw(string action, int accountNumber, double sum)
        {

            if (accounts.ContainsKey(accountNumber))
            {
                if (action == "Deposit")
                {
                    accounts[accountNumber] += sum;
                }
                else if (action == "Withdraw")
                {
                    if (sum > accounts[accountNumber])
                    {
                        throw new ArgumentException();
                    }
                    accounts[accountNumber] -= sum;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
