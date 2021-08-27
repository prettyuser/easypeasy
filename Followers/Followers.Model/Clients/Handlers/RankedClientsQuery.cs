using System.Collections.Generic;
using Followers.Model.Clients.Dto;
using Utilities.MediatR.Extensions.Queries;

namespace Followers.Model.Clients.Handlers
{ 
    /// <summary>
    /// Query to work with clients
    /// </summary>
    /// <param name="Top">Take first n elements</param>
    public record RankedClientsQuery(int Top) : Query<IEnumerable<ClientData>>;
}
