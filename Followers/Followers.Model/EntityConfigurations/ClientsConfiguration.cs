using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Followers.Model.EntityConfigurations
{
    public class ClientsConfiguration : IEntityTypeConfiguration<EfClient>
    {
        public void Configure(EntityTypeBuilder<EfClient> entity)
        {
            entity.ToTable("Clients", "dbo");
            
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasMany(p => p.Followers)
                .WithMany(c => c.Followings);
        }
    }
}