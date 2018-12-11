using MassTransit;
using NB.CheckingAccountTransaction.Domain.Contract;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Consumer
{
    public class AddInternalTransaction : IConsumer<AddInternalTransactionCommand>
    {
        public readonly ICheckingAccountTransactionDomain checkingAccountTransactionDomain;
        public AddInternalTransaction(ICheckingAccountTransactionDomain checkingAccountTransactionDomain)
        {
            this.checkingAccountTransactionDomain = checkingAccountTransactionDomain;
        }
        public async Task Consume(ConsumeContext<AddInternalTransactionCommand> context)
        {
            await context.RespondAsync(await checkingAccountTransactionDomain.AddInternalTransaction(context.Message));
        }
    }
}
