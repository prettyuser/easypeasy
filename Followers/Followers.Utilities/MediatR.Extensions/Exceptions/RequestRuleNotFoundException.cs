using System;

namespace Utilities.MediatR.Extensions.Exceptions
{
    public class RequestRuleNotFoundException : Exception
    {
        public RequestRuleNotFoundException(Type ruleType) : base($"Rule implementation for type '{ruleType.Name}' wasn't found")
        {
            RuleType = ruleType;
        }
        
        public Type RuleType { get; }

        public override string ToString() => Message;
    }
}