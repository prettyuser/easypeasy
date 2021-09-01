using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Utilities.MediatR.Extensions.Base;
using Utilities.MediatR.Extensions.Exceptions;
using Utilities.MediatR.Extensions.Rules;

namespace Utilities.MediatR.Extensions.Commands
{
    public abstract class CommandHandler<TCommand, TResult> : HandlerBase<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        protected CommandHandler(ILogger logger, IRequestRuleProvider ruleProvider) : base(logger, ruleProvider)
        { }

        private TCommand Command => Request;
        
        protected override IEnumerable<ValidationError> Validate() => Validator.ValidateRequest(Command);
        
        protected virtual InlineValidator<TCommand> Validator => new();

        protected override async Task<TResult> Handle()
        {
            return await ProcessBase().ConfigureAwait(false);
        }
        
        protected abstract Task<TResult> ProcessBase();
    }
}
