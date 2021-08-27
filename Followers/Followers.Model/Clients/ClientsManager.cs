using System;
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

        public async Task<List<EfClient>> GetClients(int top)
        {
            return await 
                _followersDbContext.Clients
                    .Include(p => p.Subscribers)
                    .OrderByDescending(e => e.Subscribers.Count)
                    .Take(top)
                    .ToListAsync();
        }

        public async Task<EfClient> GetClient(int id)
        {
            return await _followersDbContext.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> SubscribeClient(int subscriberId, int subscribingId)
        {
            var entity = new EfSubscriber(subscriberId, subscribingId);
            _followersDbContext.Followers.Add(entity);
            return await _followersDbContext.SaveDbChanges();
        }
        
        public async Task<ClientData> RegisterClient(string name)
        {
            var newEntity = new EfClient(0, name);
            _followersDbContext.Clients.Add(newEntity);
            await _followersDbContext.SaveDbChanges();

            var entity = await GetClient(newEntity.Id); 
            
            var result = new ClientData(entity.Id, entity.Name);
            return result;
        }
    }
}