using System.Collections.Generic;
using System.Threading.Tasks;
using Followers.Model.Clients.Db.Entities;

namespace Followers.Model.Clients
{
    public interface IClientsManager
    {
        Task<List<EfClient>> GetClients(int top);
        
        Task<EfClient> SubscribeClient(int id, int subscribingId);

        Task<EfClient> RegisterClient(string name);
    }
}
