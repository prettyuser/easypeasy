using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Utilities.MediatR.Extensions.Base;
using Utilities.MediatR.Extensions.Exceptions;
using Utilities.MediatR.Extensions.Rules;

namespace Utilities.MediatR.Extensions.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : HandlerBase<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private TQuery Query => Request;
        
        protected virtual InlineValidator<TQuery> Validator => new();
        
        protected override async Task<TResult> Handle() => await GetData();

        protected override IEnumerable<ValidationError> Validate() => Validator.ValidateRequest(Query);
        
        protected abstract Task<TResult> GetData();

        public override string ToString() => $"{GetType().Name} | {Query}";

        protected QueryHandler(ILogger logger, IRequestRuleProvider ruleProvider) 
            : base(logger, ruleProvider)
        {
        }
    }
}
