using MassTransit;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Threading.Tasks;

namespace NB.CheckingAccount.Domain.Consumers
{
    public class MyConsumer : IConsumer<TransportEntity>
    {
        readonly IPublishEndpoint _PublishEndpoint;
        public MyConsumer(IPublishEndpoint publishEndpoint)
        {
            _PublishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<TransportEntity> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.Sucess}");

            // update the customer address
        }
    }
}
