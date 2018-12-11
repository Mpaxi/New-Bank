using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Domain.Entities
{
    public class CheckingAccountStatus : EntityBase
    {
        public string Description { get; set; }
        public ICollection<CheckingAccount> CheckingAccount { get; set; }
    }
}
