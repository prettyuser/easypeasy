using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Followers.Model
{
    public interface IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; set; }
        public DbSet<EfFollower> Followers { get; set; }
    }
}