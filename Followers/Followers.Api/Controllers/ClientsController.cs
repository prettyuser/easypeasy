using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Followers.Model.Clients.Dto;
using Followers.Model.Clients.Handlers;
using Microsoft.Extensions.Logging;

namespace Followers.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController : ControllerBase
    {
        private IMediator Mediator { get; }
        
        private readonly ILogger _logger;

        public ClientsController(IMediator mediator, ILogger<ClientsController> logger)
        {
            _logger = logger;
            Mediator = mediator;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ClientData[]), 200)]
        public async Task<IActionResult> Get([FromQuery] int top = 100)
        {
            var query = new RankedClientsQuery(top);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ClientData), 200)]
        public async Task<IActionResult> Register([FromBody] RegisterClientRequest request)
        {
            var command = new RegisterClientCommand(request);
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(Register), result);
        }
        
        [HttpPost("{id:int}")]
        [ProducesResponseType(typeof(ClientData), 200)]
        public async Task<IActionResult> Subscribe([FromRoute] int id, [FromBody] EditSubscriptionRequest request)
        {
            var command = new SubscribeClientCommand(id, request);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
