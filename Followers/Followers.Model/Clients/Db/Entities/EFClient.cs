using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: client's information
    /// </summary>
    /// <param name="Id">Client's identifier</param>
    /// <param name="Name">Client's name</param>
    /// <param name="Rank">Client's rank</param>
    /// <param name="IsActive">Is client deleted?</param>
    public record EfClient(int Id, string Name, int? Rank, bool IsActive)
    {
        [InverseProperty("Following")]
        public virtual ICollection<EfFollower> Followings { get; set; }
        
        [InverseProperty("Follower")]
        public virtual ICollection<EfFollower> Followers { get; set; }
    }
}
