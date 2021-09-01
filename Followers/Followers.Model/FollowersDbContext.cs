using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Followers.Model.Clients.Db.Entities;
using Followers.Model.EntityConfigurations;
using Utilities.DataModels;

namespace Followers.Model
{
    public class FollowersDbContext : DbContext, IFollowersDbContext
    {
        public DbSet<EfClient> Clients { get; private set; } = default!;
        
        public DbSet<EfSubscriber> Subscribers { get; private set; } = default!;

        private string DbPath { get; }

        public FollowersDbContext(DbContextOptionsBuilder builder = null, bool test = false)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}followers.db";
        }

        public async Task<int> SaveDbChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEfEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((BaseEfEntity)entityEntry.Entity).LastModifiedOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEfEntity)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
            }
            
            return await SaveChangesAsync();
        } 

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
