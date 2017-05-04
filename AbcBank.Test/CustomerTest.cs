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
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test] //Test customer statement generation
        public void customer_can_request_a_statement()
        {

            Customer henry = new Customer("Henry")
                            .openAccount(AccountType.CHECKING)
                            .openAccount(AccountType.SAVINGS);

            henry.deposit(AccountType.CHECKING ,100.0);
            henry.deposit(AccountType.SAVINGS, 4000.0);
            henry.withdraw(AccountType.SAVINGS,  200.0);

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
            Customer oscar = new Customer("Oscar")
                .openAccount(AccountType.SAVINGS);
            Assert.AreEqual(1, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_open_checking_and_savings_account()
        {
            Customer oscar = new Customer("Oscar")
                            .openAccount(AccountType.CHECKING)
                            .openAccount(AccountType.SAVINGS);
            Assert.AreEqual(2, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_open_checking__maxi_saving_account()
        {
            Customer oscar = new Customer("Oscar")
                            .openAccount(AccountType.CHECKING)
                            .openAccount(AccountType.MAXI_SAVING)
                            .openAccount(AccountType.SAVINGS);
            Assert.AreEqual(3, oscar.getNumberOfAccounts());
        }

        [Test]
        public void customer_can_deposit_into_account()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bill.deposit(AccountType.SAVINGS, 1500.0);

            Assert.AreEqual(1500, bill.accountBalance(AccountType.SAVINGS), DOUBLE_DELTA);
        }
        [Test]
        public void customer_can_withdral_from_account()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bill.deposit(AccountType.SAVINGS, 1500.0);
            bill.withdraw(AccountType.SAVINGS, 500.0);

            Assert.AreEqual(1000, bill.accountBalance(AccountType.SAVINGS), DOUBLE_DELTA);

        }
        [Test]
        public void customer_fails_to_withdral_from_account_not_enough_funds()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bill.deposit(AccountType.SAVINGS, 500.0);
            Assert.Throws<ArgumentException>(() => bill.withdraw(AccountType.SAVINGS, 1500.0), "not enough funds");
         }

        [Test]
        public void customer_deposit_to_account_that_doesnt_exist()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.CHECKING);
            Assert.Throws<ArgumentException>(() => bill.deposit(AccountType.SAVINGS, 500.0), "account does not exist");
        }
        [Test]
        public void customer_withdrawl_from_account_that_doesnt_exist()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.CHECKING);
            Assert.Throws<ArgumentException>(() => bill.withdraw(AccountType.SAVINGS, 500.0), "account does not exist");
        }
    }
}
