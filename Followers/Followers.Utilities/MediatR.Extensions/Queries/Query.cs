using GoodsForecast.Mediatr.Extensions.Base;

namespace GoodsForecast.Mediatr.Extensions.Queries
{
    /// <summary>
    /// Базовый тип запроса - реквеста, не меняющего данные и ожидающего результат типа <typeparamref name="TResult"/>,
    /// который поддерживается хендлерами API-каркаса типа <see cref="QueryHandler{TQuery, TResult}"/>.
    /// </summary>
    /// <typeparam name="TResult">Тип ожидаемого результата.</typeparam>
    public record Query<TResult> : IRequestBase, IQuery<TResult>;
}