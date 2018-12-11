using MediatR;
using Microsoft.AspNetCore.Mvc;
using NB.CheckingAccount.Domain.Commands;
using System.Threading.Tasks;

namespace NB.CheckingAccount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingAccountController : ControllerBase
    {
        public readonly IMediator mediator;

        public CheckingAccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("InternalTransaction")]
        public async Task<IActionResult> AddCheckingAccountInternalTransaction(AddCheckingAccountTransactionCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost]
        [Route("Statement")]
        public async Task<IActionResult> GetStatement(GetStatementCommand command)
        {
            return Ok(await mediator.Send(command));
        }

    }
}