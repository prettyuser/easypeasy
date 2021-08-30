using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Followers.Model.EntityConfigurations
{
    public class SubscribersConfiguration: IEntityTypeConfiguration<EfSubscriber>
    {
        public void Configure(EntityTypeBuilder<EfSubscriber> entity)
        {
            entity.ToTable("Subscribers");

            entity.HasKey(e => new {e.ClientId, e.SubscribingId});

            entity.HasOne(e => e.Client)
                .WithMany(e => e.Clients)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Subscribing)
                .WithMany(e => e.Subscribings)
                .HasForeignKey(e => e.SubscribingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasCheckConstraint("CK_Subscribers_NotSelfReferenceAllowed", "[ClientId] <> [SubscribingId]");
            
            entity.HasCheckConstraint("CK_Subscribers_Correct_ClientId", "[ClientId] > 0");
            
            entity.HasCheckConstraint("CK_Subscribers_Correct_SubscribingId", "[SubscribingId] > 0");
        }
    }
}