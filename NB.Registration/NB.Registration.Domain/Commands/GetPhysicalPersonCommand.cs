using MediatR;
using NB.SupportPackages.Entities.Transport;
using System;

namespace NB.Registration.Domain.Commands
{
    public class GetPhysicalPersonCommand : IRequest<TransportEntity>
    {
        public Guid PhysicalPersonID { get; set; }
    }
}
