using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AbcBank.Test
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void bankmanager_can_report_customers_and_accounts()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.openAccount(AccountType.CHECKING);
            bank.addCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.customerSummary());
        }

        [Test]
        public void bankmanger_can_report_interestpaid_on_one_acount_of_type_checking()
        {
            Bank bank = new Bank();
            Customer bill = new Customer("Bill").openAccount(AccountType.CHECKING);
            bank.addCustomer(bill);

            bill.deposit(AccountType.CHECKING, 100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void bankmanger_can_report_interestpaid_on_one_acount_of_type_savings()
        {
            Bank bank = new Bank();
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bank.addCustomer(bill);
            bill.deposit(AccountType.SAVINGS, 1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void bankmanger_can_report_interestpaid_on_one_acount_of_type_maxi_savings()
        {
            Bank bank = new Bank();
            Customer bill = new Customer("Bill").openAccount(AccountType.MAXI_SAVING);
            bank.addCustomer(bill);
            bill.deposit(AccountType.MAXI_SAVING, 3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void bankmanger_can_report_interestpaid_on_all_accounts()
        {
            Bank bank = new Bank();
            Customer bill = new Customer("Bill")
                            .openAccount(AccountType.SAVINGS)
                            .openAccount(AccountType.CHECKING)
                            .openAccount(AccountType.MAXI_SAVING);
            bank.addCustomer(bill);
            bill.deposit(AccountType.MAXI_SAVING, 3000.0);
            bill.deposit(AccountType.SAVINGS, 1500.0);
            bill.deposit(AccountType.CHECKING, 100.0);
            Assert.AreEqual(170 + 2 + 0.1, bank.totalInterestPaid(), DOUBLE_DELTA);

        }
    }
}

