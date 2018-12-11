using System;

namespace NB.SupportPackages.Entities.Command.CheckingAccountTransaction
{
    public class AddInternalTransactionCommand
    {
        public Guid DebitCheckingAccount { get; set; }
        public Guid CreditCheckingAccount { get; set; }
        public Guid CurrencyTypeID { get; set; }
        public double Value { get; set; }

    }
}
