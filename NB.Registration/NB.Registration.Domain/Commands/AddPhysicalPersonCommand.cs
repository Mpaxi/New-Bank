using MediatR;
using NB.Registration.Domain.Entities;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Collections.Generic;

namespace NB.Registration.Domain.Commands
{
    public class AddPhysicalPersonCommand : IRequest<TransportEntity>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<PhysicalPersonDocument> Documents { get; set; }
        public IEnumerable<PhysicalPersonInternetAddress> InternetAddresses { get; set; }
    }
}
