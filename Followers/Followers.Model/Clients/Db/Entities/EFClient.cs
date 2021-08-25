using System;
using System.Collections.Generic;

namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: client's information
    /// </summary>
    /// <param name="Id">Client's identifier</param>
    /// <param name="Name">Client's name</param>
    /// <param name="Rank">Client's rank</param>
    /// <param name="IsActive">Is client deleted?</param>
    public record EfClient(Guid Id, string Name, int? Rank, bool IsActive)
    {
        public virtual ICollection<EfClient> Followings { get; set; } = new HashSet<EfClient>();
        
        public virtual ICollection<EfClient> Followers { get; set; } = new HashSet<EfClient>();
    }
}
