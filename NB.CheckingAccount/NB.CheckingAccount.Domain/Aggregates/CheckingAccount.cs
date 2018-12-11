using NB.CheckingAccount.Domain.Entities;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;

namespace NB.CheckingAccount.Domain.Aggregates
{
    public class CheckingAccount : EntityBase
    {

        public long Agency { get; set; }
        public long Account { get; set; }
        public long Number { get; set; }
        public Guid StatusID { get; set; }
        public CheckingAccountStatus Status { get; set; }
        public Guid AccountTypeID { get; set; }
        public CheckingAccountType AccountType { get; set; }
        public ICollection<CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
    }
}
