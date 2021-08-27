using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public record SubscribeClientCommand(EditSubscriptionRequest EditSubscriptionRequest) 
        : Command<SubscriberClientData>;
}