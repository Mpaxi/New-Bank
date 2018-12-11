using System;
using System.Collections.Generic;
using System.Text;

namespace NB.SupportPackages.Entities.Command.CheckingAccountTransaction
{
    public class AddCreditCardTransactionCommand
    {
        public Guid DebitCheckingAccount { get; set; }
        public Guid CurrencyTypeID { get; set; }
        public double Value { get; set; }
    }
}
