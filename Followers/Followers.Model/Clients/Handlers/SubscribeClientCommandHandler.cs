using System;
using System.Threading.Tasks;
using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public class SubscribeClientCommandHandler : CommandHandler<SubscribeClientCommand, SubscriberClientData>
    {
        protected override Task<SubscriberClientData> ProcessBase()
        {
            throw new Exception();
        }
    }
}