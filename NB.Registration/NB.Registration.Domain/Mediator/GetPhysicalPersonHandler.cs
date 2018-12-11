using MediatR;
using NB.Registration.Domain.Commands;
using NB.Registration.Domain.Contract;
using NB.SupportPackages.Entities.Transport;
using System.Threading;
using System.Threading.Tasks;

namespace NB.Registration.Domain.Mediator
{
    public class GetPhysicalPersonHandler : IRequestHandler<GetPhysicalPersonCommand, TransportEntity>
    {
        readonly IPhysicalPersonDomain PhysicalPersonDomain;
        public GetPhysicalPersonHandler(IPhysicalPersonDomain PhysicalPersonDomain)
        {
            this.PhysicalPersonDomain = PhysicalPersonDomain;
        }
        public async Task<TransportEntity> Handle(GetPhysicalPersonCommand request, CancellationToken cancellationToken)
        {
            return await PhysicalPersonDomain.GetPhysicalPersonByID(request.PhysicalPersonID);
        }
    }
}
