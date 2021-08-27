using System.Collections.Generic;
using System.Threading.Tasks;
using Followers.Model.Clients.Db.Entities;
using Followers.Model.Clients.Dto;

namespace Followers.Model.Clients
{
    public interface IClientsManager
    {
        Task<List<EfClient>> GetClients(int top);
    }
}