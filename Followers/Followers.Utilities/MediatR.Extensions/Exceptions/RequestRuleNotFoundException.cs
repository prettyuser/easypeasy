using System;

namespace Utilities.MediatR.Extensions.Exceptions
{
    /// <summary>
    /// Исключение при отсутствии реализации для некоторого типа правила обработки запросов.
    /// </summary>
    public class RequestRuleNotFoundException : Exception
    {
        public RequestRuleNotFoundException(Type ruleType) : base($"Rule implementation for type '{ruleType.Name}' wasn't found")
        {
            RuleType = ruleType;
        }

        /// <summary>
        /// Тип правила обработки запросов.
        /// </summary>
        public Type RuleType { get; }

        public override string ToString() => Message;
    }
}