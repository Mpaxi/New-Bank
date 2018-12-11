using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.CheckingAccount.Domain.Entities
{
    public class CheckingAccountType : EntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public ICollection<Aggregates.CheckingAccount> CheckingAccount { get; set; }
    }
}
