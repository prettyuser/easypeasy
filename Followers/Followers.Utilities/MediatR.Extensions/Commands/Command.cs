using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Commands
{
    public record Command<TResult> : IRequestBase, ICommand<TResult>;
}
