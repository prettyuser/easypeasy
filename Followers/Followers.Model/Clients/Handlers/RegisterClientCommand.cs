using System.Collections.Generic;
using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Base;
using Utilities.MediatR.Extensions.Commands;
using Utilities.MediatR.Extensions.Exceptions;

namespace Followers.Model.Clients.Handlers
{
    public record RegisterClientCommand(RegisterClientRequest RegisterClientRequest) : Command<ClientData>
    {
        public ICollection<ValidationError> Validate(IRequestBase request)
        {
            throw new System.NotImplementedException();
        }
    }
}
