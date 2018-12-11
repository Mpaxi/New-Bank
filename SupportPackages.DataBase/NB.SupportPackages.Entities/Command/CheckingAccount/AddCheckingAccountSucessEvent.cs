using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.SupportPackages.Entities.Command.CheckingAccount
{
    public class AddCheckingAccountSucessEvent : AddCheckingAccountCommand
    {
        public Guid TraceID { get; set; }
    }
}
