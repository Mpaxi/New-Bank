using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Domain.Entities
{
    public class CheckingAccount : EntityBase
    {
        public Guid StatusID { get; set; }        
        public CheckingAccountStatus Status { get; set; }
        public ICollection<Aggregates.CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
    }
}
