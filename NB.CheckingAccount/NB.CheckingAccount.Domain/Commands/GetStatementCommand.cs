using MediatR;
using NB.SupportPackages.Entities.Transport;
using System;

namespace NB.CheckingAccount.Domain.Commands
{
    public class GetStatementCommand : IRequest<TransportEntity>
    {
        public Guid CheckingAccountID { get; set; }
    }
}
