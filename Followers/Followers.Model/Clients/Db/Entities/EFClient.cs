using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Utilities.DataModels;

namespace Followers.Model.Clients.Db.Entities
{
    /// <summary>
    /// DB entity: client's information
    /// </summary>
    /// <param name="Id">Client's identifier</param>
    /// <param name="Name">Client's name</param>
    /// <param name="IsActive">Is client deleted?</param>
    public record EfClient(int Id, string Name, bool IsActive = true) : BaseEfEntity
    {
        [InverseProperty("Subscribing")]
        public virtual ICollection<EfSubscriber> Subscribings { get; set; }
        
        [InverseProperty("Client")]
        public virtual ICollection<EfSubscriber> Clients { get; set; }
    }
}
