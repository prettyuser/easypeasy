using GoodsForecast.Mediatr.Extensions.Base;
using MediatR;

namespace GoodsForecast.Mediatr.Extensions.Queries
{
    /// <summary>
    /// Базовый интерфейс запроса - реквеста, не меняющего данные и ожидающего результат типа <typeparamref name="TResult"/>,
    /// который поддерживается хендлерами API-каркаса типа <see cref="QueryHandler{TQuery, TResult}"/>.
    /// </summary>
    /// <typeparam name="TResult">Тип ожидаемого результата.</typeparam>
    public interface IQuery<out TResult> : IRequestBase, IRequest<TResult> { }
}