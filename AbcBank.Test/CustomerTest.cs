using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class CustomerTest
    {

        [Test] //Test customer statement generation
        public void customer_can_request_a_statement()
        {

            Account checkingAccount = new Account(Account.CHECKING);
            Account savingsAccount = new Account(Account.SAVINGS);

            Customer henry = new Customer("Henry").openAccount(checkingAccount).openAccount(savingsAccount);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", henry.getStatement());
        }

        [Test]
        public void customer_can_open_checking_account()
        {
            Customer oscar = new Customer("Oscar").openAccount(new Account(Account.SAVINGS));
            Assert.AreEqual(1, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_open_checking_and_savings_account()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(Account.SAVINGS));
            oscar.openAccount(new Account(Account.CHECKING));
            Assert.AreEqual(2, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_open_checking__maxi_saving_account()
        {
            Customer oscar = new Customer("Oscar")
                    .openAccount(new Account(Account.SAVINGS))
                    .openAccount(new Account(Account.MAXI_SAVINGS))
                    .openAccount(new Account(Account.CHECKING));
            Assert.AreEqual(3, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_deposit_into_account()
        {
            Assert.AreEqual(1, 2);
        }
        [Test]
        public void customer_can_withdral_from_account()
        {
            Assert.AreEqual(1, 2);
        }
        [Test]
        public void customer_tries_to_withdral_from_account_but_fails()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
