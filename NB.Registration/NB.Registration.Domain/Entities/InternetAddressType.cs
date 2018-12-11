using NB.SupportPackages.DataBase.Base;
using System.Collections.Generic;

namespace NB.Registration.Domain.Entities
{
    public class InternetAddressType : EntityBase
    {
        public string Description { get; set; }
        public ICollection<PhysicalPersonInternetAddress> PhysicalPersonInternetAddress { get; set; }
        public ICollection<LegalPersonInternetAddress> LegalPersonInternetAddress { get; set; }
    }
}
