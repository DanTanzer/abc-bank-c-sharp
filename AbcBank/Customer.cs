﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class Customer
    {
        private String name;
        private List<Account> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public String getName()
        {
            return name;
        }

        public Customer openAccount(AccountType type)
        {
            Account account = AccountFactory.CreateAccount(type);
            accounts.Add(account);
            return this;
        }
        public double accountBalance(AccountType target)
        {
            // validate this account belongs to this person
            var account = accounts.FirstOrDefault(a => a.accountType == target);
            if (account == null)
            {
                throw new Exception("No Account found " + target.ToString());
            }
            // add the money to the account
            return account.sumTransactions();
        }
        public void deposit(AccountType target, double amount)
        {
            // validate this account belongs to this person
            var account = accounts.FirstOrDefault(a => a.accountType == target);
            if (account == null)
            {
                throw new ArgumentException("account does not exist");
            }
            // add the money to the account
            account.deposit(amount);

        }
        public void withdraw(AccountType target, double amount)
        {
            // validate this account belongs to this person
            var account = accounts.FirstOrDefault(a => a.accountType == target);
            if (account == null)
            {
                throw new ArgumentException("account does not exist");
            }
            // withdrawl the money to the account
            account.withdraw(amount);
        }
        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Account a in accounts)
                total += a.interestEarned();
            return total;
        }

        /*******************************
         * This method gets a statement
         *********************************/
        public String getStatement()
        {
            //JIRA-123 Change by Joe Bloggs 29/7/1988 start
            String statement = null; //reset statement to null here
            //JIRA-123 Change by Joe Bloggs 29/7/1988 end
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (Account a in accounts)
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + toDollars(total);
            return statement;
        }

        private String statementForAccount(Account a)
        {
            String s = "";

            //Translate to pretty account type
            switch (a.getAccountType())
            {
                case AccountType.CHECKING:
                    s += "Checking Account\n";
                    break;
                case AccountType.SAVINGS:
                    s += "Savings Account\n";
                    break;
                case AccountType.MAXI_SAVING:
                    s += "Maxi Savings Account\n";
                    break;
            }

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in a.transactions)
            {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + toDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + toDollars(total);
            return s;
        }

        private String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }
    }
}
