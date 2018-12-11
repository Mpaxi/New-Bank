using System;
using System.Collections.Generic;
using System.Text;

namespace NB.SupportPackages.Entities.Command.CheckingAccountTransaction
{
    public class AddCreditCardTransactionSucessEvent : AddCreditCardTransactionCommand
    {
        public Guid TraceID { get; set; }
    }
}
