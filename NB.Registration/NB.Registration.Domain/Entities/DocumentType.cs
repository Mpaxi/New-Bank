using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.Registration.Domain.Entities
{
    public class DocumentType : EntityBase
    {
        public string Description { get; set; }
        public ICollection<PhysicalPersonDocument> PhysicalPersonDocument { get; set; }
        public ICollection<LegalPersonDocument> LegalPersonDocument { get; set; }
    }
}
