using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class AccountFactory
    {
        public static Account CreateAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.SAVINGS:
                    return new SavingAccount();
                case AccountType.MAXI_SAVING:
                    return new MaxiSavingAccount();
                case AccountType.CHECKING:
                    return new CheckingAccount();
                default:
                    throw new Exception("AccountType " + type + "has not be created");
            }
        }
    }
}
