namespace AbcBank
{
    public class SavingAccount : Account
    {
        public SavingAccount() : base(AccountType.SAVINGS)
        {
        }
        public override double interestEarned()
        {
            double amount = sumTransactions();
            if (amount <= 1000)
                return amount * 0.001;
            else
                return 1 + (amount - 1000) * 0.002;
        }
    }
}
