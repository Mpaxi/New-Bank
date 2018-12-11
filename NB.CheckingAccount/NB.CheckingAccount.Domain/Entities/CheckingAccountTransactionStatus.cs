using NB.CheckingAccount.Domain.Aggregates;
using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.CheckingAccount.Domain.Entities
{
    public class CheckingAccountTransactionStatus : EntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public ICollection<CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
    }
}
