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
    public record EfClient(int Id, string Name, int? Rank = null, bool IsActive = true)
    {
        [InverseProperty("Subscribing")]
        public virtual ICollection<EfSubscriber> Subscribings { get; set; }
        
        [InverseProperty("Client")]
        public virtual ICollection<EfSubscriber> Clients { get; set; }
    }
}
