using System.Collections.Generic;

namespace Utilities.MediatR.Extensions.Rules
{
    public interface IRequestRuleProvider
    {
        ICollection<IRequestRule> Get<TRequest>();
    }
}