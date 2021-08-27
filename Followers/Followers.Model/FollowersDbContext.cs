using System;
using System.Threading.Tasks;
using Followers.Model.Clients.Db.Entities;
using Followers.Model.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Followers.Model
{
    public class FollowersDbContext : DbContext, IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; set; }
        public DbSet<EfSubscriber> Followers { get; set; }

        private string DbPath { get; set; }

        public FollowersDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}followers.db";
        }

        public Task<int> SaveDbChanges() => SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribersConfiguration());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
