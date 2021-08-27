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

            entity.HasKey(e => new {e.SubscriberId, e.SubscribingId});

            entity.HasOne(e => e.Subscriber)
                .WithMany(e => e.Subscribers)
                .HasForeignKey(e => e.SubscriberId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Subscribing)
                .WithMany(e => e.Subscribings)
                .HasForeignKey(e => e.SubscribingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasCheckConstraint("CK_Subscribers", 
                "[SubscriberId] <> [SubscribingId]");
            
            entity.HasCheckConstraint("CK_Subscribers_SubscriberId", "[SubscriberId] > 0");
            
            entity.HasCheckConstraint("CK_Subscribers_SubscribingId", "[SubscribingId] > 0");
        }
    }
}