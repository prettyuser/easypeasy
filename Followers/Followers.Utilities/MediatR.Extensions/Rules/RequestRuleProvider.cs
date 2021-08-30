using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.MediatR.Extensions.Exceptions;
using Utilities.Reflection;

namespace Utilities.MediatR.Extensions.Rules
{
    public class RequestRuleProvider : IRequestRuleProvider
    {
        /// <summary>
        /// DI контейнер.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <param name="serviceProvider">DI контейнер.</param>
        public RequestRuleProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Получить список правил обработки данного типа реквеста.
        /// </summary>
        /// <typeparam name="TRequest">Тип реквеста.</typeparam>
        /// <returns>Список правил, применимый к данному типу реквестов.</returns>
        public ICollection<IRequestRule> Get<TRequest>()
        {
            // 1. Находим у данного типа реквеста все интерфейсы вида IRequestWithRule<..., TRuleInterface>
            // 2. По TRuleInterface получаем само правило с помощью DI-контейнера

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