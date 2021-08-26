using System;

namespace Utilities.DataModels
{
    public record BaseEfEntity(DateTime? CreatedOn, DateTime? LastModifiedOn);
}
