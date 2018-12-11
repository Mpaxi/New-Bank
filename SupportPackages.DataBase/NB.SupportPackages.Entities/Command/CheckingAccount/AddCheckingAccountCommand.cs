using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.SupportPackages.Entities.Command.CheckingAccount
{
    public class AddCheckingAccountCommand : EntityBase
    {
        public long Agency { get; set; }
        public long Account { get; set; }
        public long Number { get; set; }
        public Guid StatusID { get; set; }
        public Guid AccountTypeID { get; set; }

    }
}
