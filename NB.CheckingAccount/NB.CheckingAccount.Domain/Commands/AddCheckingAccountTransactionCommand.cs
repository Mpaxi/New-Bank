using MediatR;
using NB.SupportPackages.Entities.Transport;
using System;

namespace NB.CheckingAccount.Domain.Commands
{
    public class AddCheckingAccountTransactionCommand : IRequest<TransportEntity>
    {
        public Guid DebitCheckingAccount { get; set; }
        public Guid CreditCheckingAccount { get; set; }
        public decimal Value { get; set; }

    }
}
