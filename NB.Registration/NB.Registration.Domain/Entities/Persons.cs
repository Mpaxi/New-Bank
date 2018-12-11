using NB.Registration.Domain.Aggregates;
using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.Registration.Domain.Entities
{
    public class Persons : EntityBase
    {
        public Guid PhysicalPersonID { get; set; }
        public PhysicalPerson PhysicalPerson { get; set; }
        public Guid LegalPersonID { get; set; }
        public LegalPerson LegalPersons { get; set; }
    }
}
