using System.Threading.Tasks;
using Followers.Model.Clients.Dto;
using Followers.Model.MappingConfigs;
using Mapster;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public class RegisterClientCommandHandler : CommandHandler<RegisterClientCommand, ClientData>
    {
        private IClientsManager ClientsManager { get; }
        
        public RegisterClientCommandHandler(IClientsManager clientsManager)
        {
            ClientsManager = clientsManager;
        }
        
        protected override async Task<ClientData> ProcessBase()
        {
            var result = await ClientsManager.RegisterClient(Request.RegisterClientRequest.Name);
            return result.Adapt<ClientData>(FollowersMapping.TypeAdapterConfiguration);
        }
    }
}