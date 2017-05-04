using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank.Test
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void transaction()
        {
            Transaction t = new Transaction(5);
            Assert.AreEqual(true, t is Transaction);
        }

        [Test]
        public void transactionDate_is_set_manually()
        {
            // prime the date
            DateTime d = DateTime.Now.AddDays(-365);
            DateProvider.getInstance().SetBackDate(d);
            Transaction t = new Transaction(5);

            // reset the date
            DateProvider.getInstance().SetBackDate(DateTime.MinValue);
            // check that the date of the transaction is 365 days ago.
            Assert.AreEqual(d, t.transactionDate);
        }
    }
}
