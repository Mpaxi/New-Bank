using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.CheckingAccountTransaction.Domain.Entities
{
    public class CheckingAccountTransactionStatus : EntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public ICollection<Aggregates.CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
    }
}
