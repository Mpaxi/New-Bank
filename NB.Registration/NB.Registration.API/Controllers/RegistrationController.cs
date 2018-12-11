using MediatR;
using Microsoft.AspNetCore.Mvc;
using NB.Registration.API.ViewModel;
using System.Threading.Tasks;

namespace NB.Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public readonly IMediator mediator;

        public RegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("AddPhysicalPerson")]
        public async Task<IActionResult> AddPhysicalPerson(PhysicalPerson command)
        {
            return Ok(await mediator.Send(command.CreateCommand()));
        }
    }
}