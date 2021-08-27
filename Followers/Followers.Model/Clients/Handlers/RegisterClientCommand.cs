using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Commands;

namespace Followers.Model.Clients.Handlers
{
    public record RegisterClientCommand(RegisterClientRequest registerClientCommand) : Command<ClientData>;
}
