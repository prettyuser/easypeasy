using MediatR;
using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Commands
{
    public interface ICommand<out TResult>: IRequestBase, IRequest<TResult> { }
}
