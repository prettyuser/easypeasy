using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Utilities.MediatR.Extensions.Queries;
using Followers.Model.MappingConfigs;
using Followers.Model.Clients.Dto;
using Microsoft.Extensions.Logging;
using Utilities.MediatR.Extensions.Rules;

namespace Followers.Model.Clients.Handlers
{
    public class RankedClientsQueryHandler : QueryHandler<RankedClientsQuery, IEnumerable<ClientData>>
    {
        private IClientsManager ClientsManager { get; }
        
        public RankedClientsQueryHandler(
            ILogger<RankedClientsQueryHandler> logger, 
            IRequestRuleProvider ruleProvider,
            IClientsManager clientsManager) : base(logger, ruleProvider)
        {
            ClientsManager = clientsManager;
        }
            
        protected override async Task<IEnumerable<ClientData>> GetData()
        {
            var result = await ClientsManager.GetClients(Request.Top);
            return result.Adapt<List<ClientData>>(FollowersMapping.TypeAdapterConfiguration);
        }
    }
}
