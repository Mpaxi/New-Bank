using NB.Registration.Domain.Entities;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;

namespace NB.Registration.Domain.Aggregates
{
    public class LegalPerson : EntityBase
    {
        public string Name { get; set; }
        public string PublicName { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<LegalPersonDocument> Documents { get; set; }
        public ICollection<LegalPersonInternetAddress> InternetAddresses { get; set; }
        public ICollection<Persons> Persons { get; set; }
    }
}
