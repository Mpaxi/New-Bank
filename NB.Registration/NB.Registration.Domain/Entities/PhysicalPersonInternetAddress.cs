using NB.Registration.Domain.Aggregates;
using NB.SupportPackages.DataBase.Base;
using System;

namespace NB.Registration.Domain.Entities
{
    public class PhysicalPersonInternetAddress : EntityBase
    {
        public string Value { get; set; }
        public Guid InternetAddressTypeID { get; set; }
        public InternetAddressType InternetAddressType { get; set; }
        public Guid PhysicalPersonID { get; set; }
        public PhysicalPerson PhysicalPerson { get; set; }

    }
}
