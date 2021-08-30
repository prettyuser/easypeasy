using System;

namespace Utilities.DataModels
{
    public record BaseEfEntity()
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
