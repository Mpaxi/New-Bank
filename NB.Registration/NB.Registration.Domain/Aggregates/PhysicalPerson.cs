using NB.Registration.Domain.Entities;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;

namespace NB.Registration.Domain.Aggregates
{
    public class PhysicalPerson : EntityBase
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<PhysicalPersonDocument> Documents { get; set; }
        public ICollection<PhysicalPersonInternetAddress> InternetAddresses { get; set; }
        public ICollection<Persons> Persons { get; set; }


    }
}
