using System.Threading.Tasks;
using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public class SubscribeClientCommandHandler : CommandHandler<SubscribeClientCommand, SubscriberClientData>
    {
        private IClientsManager ClientsManager { get; set; }
        
        public SubscribeClientCommandHandler(IClientsManager clientsManager)
        {
            ClientsManager = clientsManager;
        }

        protected override async Task<SubscriberClientData> ProcessBase()
        {
            var processed = await ClientsManager.SubscribeClient(
                Request.EditSubscriptionRequest.SubscriberId,
                Request.EditSubscriptionRequest.SubscribingId);

            if (processed > 0) 
            {
                return new SubscriberClientData(
                    Request.EditSubscriptionRequest.SubscribingId, 
                    Request.EditSubscriptionRequest.SubscriberId);
            }

            return new SubscriberClientData(0, 0);
        }
    }
}