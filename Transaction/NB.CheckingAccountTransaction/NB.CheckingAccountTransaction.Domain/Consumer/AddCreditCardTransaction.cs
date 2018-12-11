using MassTransit;
using NB.CheckingAccountTransaction.Domain.Contract;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Consumer
{
    public class AddCreditCardTransaction : IConsumer<AddCreditCardTransactionCommand>
    {
        public readonly ICheckingAccountTransactionDomain checkingAccountTransactionDomain;
        public AddCreditCardTransaction(ICheckingAccountTransactionDomain checkingAccountTransactionDomain)
        {
            this.checkingAccountTransactionDomain = checkingAccountTransactionDomain;
        }
        public async Task Consume(ConsumeContext<AddCreditCardTransactionCommand> context)
        {
            await context.RespondAsync(await checkingAccountTransactionDomain.AddCardTransaction(context.Message));
        }
    }
}
