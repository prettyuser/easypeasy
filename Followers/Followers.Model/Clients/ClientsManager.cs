using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Followers.Model.Clients.Db.Entities;

namespace Followers.Model.Clients
{
    public class ClientsManager : IClientsManager
    {
        private readonly ILogger _logger;
        
        private readonly IFollowersDbContext _followersDbContext;
        
        public ClientsManager(IFollowersDbContext followersDbContext, ILogger<ClientsManager> logger)
        {
            _logger = logger;
            _followersDbContext = followersDbContext;
        }

        public async Task<List<EfClient>> GetClients(int top)
        {
            return await 
                _followersDbContext.Clients
                    .AsNoTracking()
                    .Include(p => p.Subscribings)
                    .OrderByDescending(e => e.Subscribings.Count)
                    .Take(top)
                    .ToListAsync();
        }

        public async Task<EfClient> GetClient(int id)
        {
            return await 
                _followersDbContext.Clients
                .AsNoTracking()
                .Include(p => p.Subscribings)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<EfClient> SubscribeClient(int clientId, int subscribingId)
        {
            var subscription = new EfSubscriber(clientId, subscribingId);
            _followersDbContext.Subscribers.Add(subscription);
            await _followersDbContext.SaveDbChanges();
            
            var entity = await GetClient(subscribingId);
            
            return entity;
        }
        
        public async Task<EfClient> RegisterClient(string name)
        {
            var newEntity = new EfClient(0, name);
            _followersDbContext.Clients.Add(newEntity);
            await _followersDbContext.SaveDbChanges();

            return await GetClient(newEntity.Id);
        }
    }
}