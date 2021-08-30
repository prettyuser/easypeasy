using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Followers.Model.Clients.Dto;
using Followers.Model.MappingConfigs;
using Mapster;
using Utilities.MediatR.Extensions.Commands;
using Utilities.MediatR.Extensions.Rules;

namespace Followers.Model.Clients.Handlers
{
    public class SubscribeClientCommandHandler : CommandHandler<SubscribeClientCommand, ClientData>
    {
        private IClientsManager ClientsManager { get; }
        
        public SubscribeClientCommandHandler(
            ILogger<SubscribeClientCommandHandler> logger,  
            IRequestRuleProvider ruleProvider,
            IClientsManager clientsManager) : base(logger, ruleProvider)
        {
            ClientsManager = clientsManager;
        }

        protected override async Task<ClientData> ProcessBase()
        {
            var result = await ClientsManager.SubscribeClient(
                Request.Id,
                Request.Request.SubscribingId);

            return result.Adapt<ClientData>(FollowersMapping.TypeAdapterConfiguration);
        }
    }
}