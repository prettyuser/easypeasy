using MediatR;
using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Queries
{
    public interface IQuery<out TResult> : IRequestBase, IRequest<TResult> { }
}
