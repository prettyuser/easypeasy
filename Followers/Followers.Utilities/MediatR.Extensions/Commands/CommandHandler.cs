using System.Threading.Tasks;
using MediatR;
using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Commands
{
    public abstract class CommandHandler<TCommand, TResult> : HandlerBase<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        protected TCommand Command => Request;
        
        protected override async Task<TResult> Handle()
        {
            return await ProcessBase().ConfigureAwait(false);
        }
        
        protected abstract Task<TResult> ProcessBase();
    }
    
    public abstract class CommandHandler<TCommand> : CommandHandler<TCommand, Unit>
        where TCommand : ICommand
    {
        protected override async Task<Unit> ProcessBase()
        {
            await Process().ConfigureAwait(false);
            return Unit.Value;
        }
        
        protected abstract Task Process();
    }
}
