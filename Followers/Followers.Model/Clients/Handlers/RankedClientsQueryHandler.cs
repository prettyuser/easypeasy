using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Utilities.MediatR.Extensions.Queries;
using Followers.Model.MappingConfigs;
using Followers.Model.Clients.Dto;

namespace Followers.Model.Clients.Handlers
{
    public class RankedClientsQueryHandler : QueryHandler<RankedClientsQuery, IEnumerable<ClientData>>
    {
        private readonly IClientsManager _clientsManager;
        
        public RankedClientsQueryHandler(IClientsManager clientsManager)
        {
            _clientsManager = clientsManager;
        }
            
        protected override async Task<IEnumerable<ClientData>> GetData()
        {
            var result = await _clientsManager.GetClients(Request.Top);
            return result.Adapt<List<ClientData>>(FollowersMapping.TypeAdapterConfiguration);
        }
    }
}
