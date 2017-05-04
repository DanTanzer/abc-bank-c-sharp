using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank.Test
{
    [TestFixture]
    public class AccountTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void accounttype_checking_interestrate_test()
        { 
            Customer bill = new Customer("Bill").openAccount(AccountType.CHECKING);
            bill.deposit(AccountType.CHECKING, 3000.0);

            Assert.AreEqual(3000 * 0.001, bill.totalInterestEarned(), DOUBLE_DELTA);
        }
        [Test]
        public void accounttype_savings_interestrate_more_then_1000()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bill.deposit(AccountType.SAVINGS, 2000.0);
            Assert.AreEqual(1 + (2000 - 1000) * 0.002, bill.totalInterestEarned(), DOUBLE_DELTA);
        }
        [Test]
        public void accounttype_savings_interestrate_less_then_1000()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.SAVINGS);
            bill.deposit(AccountType.SAVINGS, 500.0);
            Assert.AreEqual(500 * 0.001, bill.totalInterestEarned(), DOUBLE_DELTA);
        }
        [Test]
        public void accounttype_maxi_savings_interestrate_test()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.MAXI_SAVING);
            bill.deposit(AccountType.MAXI_SAVING, 3000.0);
            Assert.AreEqual(3000 * 0.05, bill.totalInterestEarned(), DOUBLE_DELTA);
        }

        [Test]
        public void accounttype_maxi_savings_interestrate_withdrawl_less_then_10_days_test()
        {
            Customer bill = new Customer("Bill").openAccount(AccountType.MAXI_SAVING);
            bill.deposit(AccountType.MAXI_SAVING, 3000.0);
            bill.withdraw(AccountType.MAXI_SAVING, 100);
            Assert.AreEqual(2900 * 0.01, bill.totalInterestEarned(), DOUBLE_DELTA);
        }

        [Test]
        public void accounttype_maxi_savings_interestrate_withdrawl_more_then_10_days_test()
        {
            // set the date back so all transactions have back a year
            DateProvider.getInstance().SetBackDate(DateTime.Now.AddDays(-365));

            Customer bill = new Customer("Bill").openAccount(AccountType.MAXI_SAVING);
            bill.deposit(AccountType.MAXI_SAVING, 3000.0);
            bill.withdraw(AccountType.MAXI_SAVING, 100);

            // reset it
            DateProvider.getInstance().SetBackDate(DateTime.MinValue);

            Assert.AreEqual(2900 * 0.05, bill.totalInterestEarned(), DOUBLE_DELTA);
        }
    }
}
