using System;

namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: follower's information
    /// </summary>
    /// <param name="FollowerId">Follower</param>
    /// <param name="FollowingId">Following</param>
    public record EfFollower(int FollowerId, int FollowingId)
    {
        public virtual EfClient Follower { get; set; }
        
        public virtual EfClient Following { get; set; }
    }
}
