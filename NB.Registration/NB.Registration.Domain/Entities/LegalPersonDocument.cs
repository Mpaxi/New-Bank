using NB.Registration.Domain.Aggregates;
using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.Registration.Domain.Entities
{
    public class LegalPersonDocument : EntityBase
    {
        public string Value { get; set; }
        public DateTime ValidDate { get; set; }
        public Guid DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }
        public Guid LegalPersonID { get; set; }
        public LegalPerson LegalPerson { get; set; }
    }
}
