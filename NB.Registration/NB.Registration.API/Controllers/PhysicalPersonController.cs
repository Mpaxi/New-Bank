using MediatR;
using Microsoft.AspNetCore.Mvc;
using NB.Registration.Domain.Commands;
using System.Threading.Tasks;

namespace NB.Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalPersonController : ControllerBase
    {
        public readonly IMediator mediator;

        public PhysicalPersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("GetPhysicalPerson")]
        public async Task<IActionResult> GetPhysicalPerson(GetPhysicalPersonCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}