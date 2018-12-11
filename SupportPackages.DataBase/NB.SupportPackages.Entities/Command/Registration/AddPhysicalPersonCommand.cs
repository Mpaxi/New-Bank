using System;
using System.Collections.Generic;

namespace NB.SupportPackages.Entities.Command.Registration
{
    public class AddPhysicalPersonCommand
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<PhysicalPersonDocument> Documents { get; set; }
        public IEnumerable<PhysicalPersonInternetAddress> InternetAddresses { get; set; }
    }

    public class PhysicalPersonDocument
    {
        public string value { get; set; }
        public DateTime validDate { get; set; }
        public Guid documentTypeID { get; set; }

    }
    public class PhysicalPersonInternetAddress
    {
        public string value { get; set; }
        public Guid internetAddressTypeID { get; set; }
    }
}
