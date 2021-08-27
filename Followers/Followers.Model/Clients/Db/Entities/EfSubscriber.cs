namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: follower's (subscriber's) information
    /// </summary>
    /// <param name="SubscriberId">Follower</param>
    /// <param name="SubscribingId">Following</param>
    public record EfSubscriber(int SubscriberId, int SubscribingId)
    {
        public virtual EfClient Subscriber { get; set; }
        
        public virtual EfClient Subscribing { get; set; }
    }
}
