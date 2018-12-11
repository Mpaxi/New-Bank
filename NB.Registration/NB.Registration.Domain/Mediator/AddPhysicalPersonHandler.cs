using MassTransit;
using MediatR;
using NB.Registration.Domain.Commands;
using NB.Registration.Domain.Contract;
using NB.SupportPackages.Entities.Command.CheckingAccount;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NB.Registration.Domain.Mediator
{
    public class AddPhysicalPersonHandler : IRequestHandler<AddPhysicalPersonCommand, TransportEntity>
    {
        readonly IPhysicalPersonDomain PhysicalPersonDomain;
        readonly IPublishEndpoint publishEndpoint;
        public AddPhysicalPersonHandler(IPhysicalPersonDomain PhysicalPersonDomain, IPublishEndpoint publishEndpoint)
        {
            this.PhysicalPersonDomain = PhysicalPersonDomain;
            this.publishEndpoint = publishEndpoint;
        }
        public async Task<TransportEntity> Handle(AddPhysicalPersonCommand request, CancellationToken cancellationToken)
        {
            Guid Key = Guid.NewGuid();
            request.ID = Key;
            var ObjReturn = await PhysicalPersonDomain.AddPhysicalPerson(request);

            Random random = new Random();

            AddCheckingAccountCommandEX addCheckingAccountCommand = new AddCheckingAccountCommandEX
            {
                ID = Key,
                AccountTypeID = Guid.Parse("1417063B-B22D-4C68-8784-DB4D32D9FDB5"),
                StatusID = Guid.Parse("F226FAEA-4E74-4826-B757-3374C378C072"),
                Agency = random.Next(0000001, 9999999),
                Account = random.Next(0000001, 9999999),
                Number = random.Next(1, 9),
                Active = true,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow


            };

            await publishEndpoint.Publish<AddCheckingAccountCommandEX>(addCheckingAccountCommand);

            return ObjReturn;
            //return await PhysicalPersonDomain.AddPhysicalPerson(request);
        }
    }
}
