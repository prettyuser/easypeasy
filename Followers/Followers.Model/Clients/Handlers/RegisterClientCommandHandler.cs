using System.Threading.Tasks;
using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public class RegisterClientCommandHandler : CommandHandler<RegisterClientCommand, ClientData>
    {
        private IClientsManager ClientsManager { get; set; }
        
        public RegisterClientCommandHandler(IClientsManager clientsManager)
        {
            ClientsManager = clientsManager;
        }
        
        protected override async Task<ClientData> ProcessBase()
        {
            return await ClientsManager.RegisterClient(Request.registerClientCommand.ClientName);
        }
    }
}