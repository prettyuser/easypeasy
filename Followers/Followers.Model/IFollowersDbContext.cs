using System.Threading.Tasks;
using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Followers.Model
{
    public interface IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; }
        
        public DbSet<EfSubscriber> Subscribers { get; }

        public Task<int> SaveDbChanges();
    }
}
