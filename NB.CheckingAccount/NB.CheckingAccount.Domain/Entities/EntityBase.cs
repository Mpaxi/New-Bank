using System;

namespace NB.CheckingAccount.Repository.Entities
{
    public class EntityBase
    {
        public Guid ID { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        
    }
}