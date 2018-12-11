using NB.Registration.Domain.Aggregates;
using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.Registration.Domain.Entities
{
    public class LegalPersonInternetAddress : EntityBase
    {
        public string Value { get; set; }
        public Guid InternetAddressTypeID { get; set; }
        public InternetAddressType InternetAddressType { get; set; }
        public Guid LegalPersonID { get; set; }
        public LegalPerson LegalPerson { get; set; }

    }
}
