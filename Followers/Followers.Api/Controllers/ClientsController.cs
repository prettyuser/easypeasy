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
        public async Task<IEnumerable<ClientData>> Get()
        {
            //ODataQueryOptions<EfClient> queryOptions
            var query = new RankedClientsQuery();
            //q => (IQueryable<EfClient>)queryOptions.ApplyTo(q)
            return await Mediator.Send(query);
        }
    }
}