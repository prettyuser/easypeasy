using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Followers.Model.Clients.Db.Entities;
using Followers.Model.Clients.Dto;
using Microsoft.EntityFrameworkCore;
using Utilities.MediatR.Extensions.Queries;

namespace Followers.Model.Clients
{
    public class ClientsManager : IClientsManager
    {
        private readonly IFollowersDbContext _followersDbContext;
        
        public ClientsManager(IFollowersDbContext followersDbContext)
        {
            _followersDbContext = followersDbContext;
        }
        public Task<int> Register()
        {
            return Task.FromResult(0);
        }

        public async Task<List<EfClient>> GetClients(int top)
        {
            return await 
                _followersDbContext.Clients
                    .Include(p => p.Subscribers)
                    .OrderByDescending(e => e.Subscribers.Count)
                    .Take(top)
                    .ToListAsync();
        }
    }
}