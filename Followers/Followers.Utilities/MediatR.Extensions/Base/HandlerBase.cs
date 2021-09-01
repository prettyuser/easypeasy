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
        private readonly ILogger _logger;

        private readonly IRequestRuleProvider _ruleProvider;

        protected HandlerBase(ILogger logger, IRequestRuleProvider ruleProvider)
        {
            _ruleProvider = ruleProvider;
            _logger = logger;
        }
        
        private ICollection<IRequestRule> Rules { get; set; }

        protected TRequest Request { get; private set; }

        protected abstract Task<TResponse> Handle();

        protected virtual IEnumerable<ValidationError> Validate() => new List<ValidationError>(0);

        public async Task<TResponse> Handle(TRequest request, CancellationToken _)
        {
            TResponse result;
            Request = request;

            try
            {
                Rules = _ruleProvider.Get<TRequest>();
                
                ValidateBase();
                result = await Handle();
            }
            catch (Exception ex)
            {
                throw await ProcessError(ex);
            }

            return result;
        }
        
        private Task<Exception> ProcessError(Exception exception)
        {
            _logger.LogError(exception, $"Error during processing request [{Request}]");

            return Task.FromResult(exception);
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
        
        public override string ToString() => $"{GetType().Name} | {Request}";
    }
}
