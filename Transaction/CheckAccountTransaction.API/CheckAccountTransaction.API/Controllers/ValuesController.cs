using CheckAccountTransaction.API.Helper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NB.SupportPackages.Entities.Command.CheckingAccountTransaction;
using NB.SupportPackages.Entities.Transport;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CheckAccountTransaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRequestClient<AddCheckingAccountTransactionCommand> _requestClient;

        public ValuesController(IRequestClient<AddCheckingAccountTransactionCommand> _requestClient)
        {
            this._requestClient = _requestClient;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("SendCheckingAccountTransaction")]

        public async Task<IActionResult> PostSendCheckingAccountTransaction(CancellationToken token, [FromBody] int Requests)
        {
            Random rnd = new Random();
            try
            {
                AddCheckingAccountTransactionCommand AddCheckingAccountTransactionCommand = new AddCheckingAccountTransactionCommand()
                {
                    CreditCheckingAccount = Guid.Parse("63F400DF-D01A-46E0-960A-5465A86C62BF"),
                    DebitCheckingAccount = Guid.Parse("22c3f8d0-5cb9-4d29-a300-52c0adc27704"),
                    CurrencyTypeID = Guid.Parse("6B577276-DDC9-4C8E-896A-EEE8396EFF82"),
                    Value = rnd.Next(1, 9999999)
                };


                var request = _requestClient.Create(AddCheckingAccountTransactionCommand,token, TimeSpan.FromMilliseconds(600));

                var response = await request.GetResponse<TransportEntity>();


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
