using System;

namespace AbcBank
{
    public class Transaction
    {
        public readonly double amount;

        public DateTime transactionDate;

        public Transaction(double amount)
        {
            this.amount = amount;
            this.transactionDate = DateProvider.getInstance().now();
        }

    }
}
