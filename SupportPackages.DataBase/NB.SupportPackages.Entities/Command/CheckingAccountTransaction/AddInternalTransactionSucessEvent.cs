using System;
using System.Collections.Generic;
using System.Text;

namespace NB.SupportPackages.Entities.Command.CheckingAccountTransaction
{
    public class AddInternalTransactionSucessEvent : AddInternalTransactionCommand
    {
        public Guid TraceID { get; set; }
    }
}
