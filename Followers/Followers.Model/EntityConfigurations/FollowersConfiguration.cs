using Followers.Model.Clients.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Followers.Model.EntityConfigurations
{
    public class FollowersConfiguration: IEntityTypeConfiguration<EfFollower>
    {
        public void Configure(EntityTypeBuilder<EfFollower> entity)
        {
            entity.ToTable("Followers");

            entity.HasKey(e => new {e.FollowerId, e.FollowingId});

            entity.HasOne(e => e.Follower)
                .WithMany(e => e.Followers)
                .HasForeignKey(e => e.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Following)
                .WithMany(e => e.Followings)
                .HasForeignKey(e => e.FollowingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasCheckConstraint("CK_Followers", 
                "[FollowerId] <> [FollowingId]");
            
            entity.HasCheckConstraint("CK_Followers_FollowerId", "[FollowerId] > 0");
            
            entity.HasCheckConstraint("CK_Followers_FollowingId", "[FollowingId] > 0");
        }
    }
}