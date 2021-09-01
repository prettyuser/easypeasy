using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Followers.Model.Clients.Db.Entities;

namespace Followers.Model.EntityConfigurations
{
    public class ClientsConfiguration : IEntityTypeConfiguration<EfClient>
    {
        public void Configure(EntityTypeBuilder<EfClient> entity)
        {
            entity.ToTable("Clients");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(1);

            entity.HasIndex(e => e.Id)
                .IsUnique();

            entity.HasIndex(e => e.Name)
                .IsUnique();
            
            entity.HasCheckConstraint("CK_Clients_Id", "[Id] > 0");
        }
    }
}