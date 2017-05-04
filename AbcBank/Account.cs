using System;
using System.Collections.Generic;

namespace AbcBank
{
    public abstract class Account
    {
        public readonly AccountType accountType;
        public List<Transaction> transactions;

        public Account(AccountType accountType)
        {
            this.accountType = accountType;
            this.transactions = new List<Transaction>();
        }

        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(amount));
            }
        }

        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(-amount));
            }
        }
        public abstract double interestEarned();
      
        public double sumTransactions()
        {
            return checkIfTransactionsExist(true);
        }

        private double checkIfTransactionsExist(bool checkAll)
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }

        public AccountType getAccountType()
        {
            return accountType;
        }

    }
}
