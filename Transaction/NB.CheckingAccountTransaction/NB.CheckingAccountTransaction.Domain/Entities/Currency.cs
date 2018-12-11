using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.CheckingAccountTransaction.Domain.Entities
{
    public class Currency : EntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public ICollection<Aggregates.CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
    }
}
