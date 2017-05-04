using System;
using System.Linq;
namespace AbcBank
{

    public class MaxiSavingAccount : Account
    {
        public MaxiSavingAccount() : base(AccountType.MAXI_SAVING)
        {
        }

        public DateTime lastWithdrawlDate()
        {
            var last = transactions.Where(x => x.amount < 0)
                               .OrderBy(x => x.transactionDate)
                               .FirstOrDefault();

            if (last != null)
                return last.transactionDate;
            else
                return DateTime.MinValue;
        }
        public override double interestEarned()
        {
            DateTime lastWithdrawl = lastWithdrawlDate();
            double amount = sumTransactions();
            if (lastWithdrawl != null && lastWithdrawl > DateTime.Now.AddDays(-10))
            {
                return amount * .01;
            }
            return amount * 0.05;

        }
        //public override double interestEarned()
        //{
        //    double amount = sumTransactions();
        //    if (amount <= 1000)
        //        return amount * 0.02;
        //    if (amount <= 2000)
        //        return 20 + (amount - 1000) * 0.05;
        //    return 70 + (amount - 2000) * 0.1;
        //}
    }
}
