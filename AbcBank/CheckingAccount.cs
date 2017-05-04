using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class CheckingAccount : Account
    {
        public CheckingAccount() : base(AccountType.CHECKING)
        {

        }
        public override double interestEarned()
        {
            double amount = sumTransactions();
            return amount * 0.001;
        }
    }
}
