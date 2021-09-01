using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Queries
{
    public record Query<TResult> : IQuery<TResult>;
}
