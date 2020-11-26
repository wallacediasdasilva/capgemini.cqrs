using MediatR;
using MediatRAPI.Application.AppTeam.Command;
using MediatRAPI.Application.AppTeam.Query.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamCreateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TeamUpdateCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new TeamDeleteCommand { Id = id };
            return Ok(await _mediator.Send(dto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = new TeamGetCommand { Id = id };
            return Ok(await _mediator.Send(dto));
        }
    }
}
