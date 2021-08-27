using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Followers.Model.Clients.Dto;
using Followers.Model.Clients.Handlers;

namespace Followers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private IMediator Mediator { get; }

        public ClientsController(IMediator mediator)
        {
            Mediator = mediator;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<ClientData>> Get(int top = 0)
        {
            var query = new RankedClientsQuery(top);
            return await Mediator.Send(query);
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<SubscriberClientData> Subscribe(EditSubscriptionRequest request)
        {
            var command = new SubscribeClientCommand(request);
            return await Mediator.Send(command);
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<ClientData> Register(RegisterClientRequest request)
        {
            var command = new RegisterClientCommand(request);
            return await Mediator.Send(command);
        }
    }
}
