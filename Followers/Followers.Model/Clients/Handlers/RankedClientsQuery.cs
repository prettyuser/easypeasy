using System.Collections.Generic;
using Followers.Model.Clients.Dto;
using GoodsForecast.Mediatr.Extensions.Queries;

namespace Followers.Model.Clients.Handlers
{ 
    public record RankedClientsQuery() : Query<IEnumerable<ClientData>>;
    //QueryableDecorator<EfClient> ApplyOData
}
