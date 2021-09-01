using Utilities.DataModels;

namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: follower's (subscriber's) information
    /// </summary>
    /// <param name="ClientId">Client's Id</param>
    /// <param name="SubscribingId">Following Id</param>
    public record EfSubscriber(int ClientId, int SubscribingId) : BaseEfEntity
    {
        public virtual EfClient Client { get; set; }
        
        public virtual EfClient Subscribing { get; set; }
    }
}
