using System;
using System.Linq;
using System.Collections.Generic;
using Utilities.MediatR.Extensions.Exceptions;
using Utilities.Reflection;

namespace Utilities.MediatR.Extensions.Rules
{
    public class RequestRuleProvider : IRequestRuleProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestRuleProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public ICollection<IRequestRule> Get<TRequest>()
        {
            var ruleTypes = typeof(TRequest)
                .GetInterfaces() 
                .SelectMany(q => q.GetClosedGenericInterfaceAttributes(typeof(IRequestWithRule<,>), 1));
            var result = new List<IRequestRule>();

            foreach (var ruleType in ruleTypes)
            {
                var rule = (IRequestRule) _serviceProvider.GetService(ruleType);

                if (rule == null)
                    throw new RequestRuleNotFoundException(ruleType);
                result.Add(rule);
            }

            return result;
        }
    }
}