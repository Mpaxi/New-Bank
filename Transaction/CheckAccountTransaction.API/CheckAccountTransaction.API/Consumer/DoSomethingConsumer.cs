using CheckAccountTransaction.API.Helper;
using MassTransit;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAccountTransaction.API.Consumer
{
    public class DoSomethingConsumer :
        IConsumer<AddCheckingAccountTransactionCommand>
    {
        private readonly IService _service;

        public DoSomethingConsumer(IService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<AddCheckingAccountTransactionCommand> context)
        {
            await _service.ServiceTheThing("");

            TransportEntity ObjReturn = new TransportEntity();
            ObjReturn.Sucess = false;
            ObjReturn.Messages.Add("Valor deve ser maior que 0");

            await context.RespondAsync<TransportEntity>(ObjReturn);
        }
    }
}
