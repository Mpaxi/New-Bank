using MassTransit;
using NB.CheckingAccountTransaction.Domain.Contract;
using NB.SupportPackages.Entities.Command.CheckingAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Domain.Consumer
{
    public class CheckingAccountCreated : IConsumer<AddCheckingAccountSucessEvent>
    {
        public readonly ICheckingAccountDomain checkingAccounDomain;
        public CheckingAccountCreated(ICheckingAccountDomain checkingAccounDomain)
        {
            this.checkingAccounDomain = checkingAccounDomain;
        }
        public async Task Consume(ConsumeContext<AddCheckingAccountSucessEvent> context)
        {
            await checkingAccounDomain.AddCheckingAccount(context.Message);
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message}");
           
        }
    }
}
