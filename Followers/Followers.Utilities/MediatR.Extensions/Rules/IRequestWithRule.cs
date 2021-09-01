using System.Diagnostics.CodeAnalysis;

namespace Utilities.MediatR.Extensions.Rules
{
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public interface IRequestWithRule<T, out TRuleInterface> where TRuleInterface : IRequestRule { }
}