using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Followers.Model
{
    public class IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; }
    }
}