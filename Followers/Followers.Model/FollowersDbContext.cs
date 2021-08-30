using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Followers.Model.Clients.Db.Entities;
using Followers.Model.EntityConfigurations;

namespace Followers.Model
{
    public class FollowersDbContext : DbContext, IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; }
        public DbSet<EfSubscriber> Subscribers { get; }

        private string DbPath { get; }

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
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite($"Data Source = {DbPath}; Foreign Keys = True");
            options.LogTo(Console.WriteLine);
        }
    }
}
