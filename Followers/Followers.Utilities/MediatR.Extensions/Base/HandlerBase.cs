using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediatR;
using Utilities.MediatR.Extensions.Exceptions;
using Utilities.MediatR.Extensions.Rules;

namespace Utilities.MediatR.Extensions.Base
{
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequestBase, IRequest<TResponse>
    {
        public HandlerBase(ILogger logger, IRequestRuleProvider ruleProvider)
        {
            RuleProvider = ruleProvider;
            Logger = logger;
        }
        
        protected readonly ILogger Logger;
        
        protected readonly IRequestRuleProvider RuleProvider;

        protected TRequest Request;
        
        protected ICollection<IRequestRule> Rules;
        
        protected abstract Task<TResponse> Handle();
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken _)
        {
            TResponse result;
            Request = request;

            try
            {
                Rules = RuleProvider.Get<TRequest>();
                
                ValidateBase();
                result = await Handle();
            }
            catch (Exception ex)
            {
                throw await ProcessError(ex);
            }

            return result;
        }

        private void ValidateBase()
        {
            var errors = new List<ValidationError>();

            foreach (var rule in Rules)
                errors.AddRange(rule.Validate(Request));

            errors.AddRange(Validate());

            if (errors != null && errors.Any())
                throw new RequestValidationException(errors);
        }
        
        protected virtual IEnumerable<ValidationError> Validate() => new List<ValidationError>(0);

        public override string ToString() => $"{GetType().Name} | {Request}";
        
        private Task<Exception> ProcessError(Exception exception)
        {
            Logger.LogError(exception, $"Error during processing request [{Request}]");

            return Task.FromResult(exception);
        }
    }
}
