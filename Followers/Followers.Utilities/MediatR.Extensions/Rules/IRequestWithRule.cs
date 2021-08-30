using System.Diagnostics.CodeAnalysis;

namespace Utilities.MediatR.Extensions.Rules
{
    /// <summary>
    /// Базовый интерфейс для реквестов с заданными правилами обработки, которые поддерживается хендлерами API-каркаса.
    /// </summary>
    /// <typeparam name="T">Тип поля в реквесте, которое обрабатывается правилом.</typeparam>
    /// <typeparam name="TRuleInterface">Интерфейс правила обработки реквестов.</typeparam>
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public interface IRequestWithRule<T, out TRuleInterface> where TRuleInterface : IRequestRule { }
}