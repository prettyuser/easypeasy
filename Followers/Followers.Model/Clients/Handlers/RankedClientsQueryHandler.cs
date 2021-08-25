using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Followers.Model.Clients.Dto;
using GoodsForecast.Mediatr.Extensions.Queries;
using Mapster;

namespace Followers.Model.Clients.Handlers
{
    public class RankedClientsQueryHandler : QueryHandler<RankedClientsQuery, IEnumerable<ClientData>>
    {
        private readonly IFollowersDbContext _followersDbContext;

        public RankedClientsQueryHandler(IFollowersDbContext followersDbContext)
        {
            _followersDbContext = followersDbContext;
        }
        
        protected override async Task<IEnumerable<ClientData>> GetData()
        {
            return (await 
                _followersDbContext
                .Clients
                .ToListAsync())
                .Adapt<IEnumerable<ClientData>>();
        }
    }
}