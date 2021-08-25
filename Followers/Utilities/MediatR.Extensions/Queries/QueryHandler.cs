using GoodsForecast.Mediatr.Extensions.Base;
using System.Threading.Tasks;

namespace GoodsForecast.Mediatr.Extensions.Queries
{
    /// <summary>
    /// Базовый тип хендлеров, обрабатывающих запросы - реквесты типа <see cref="IQuery{TResult}"/>,
    /// не меняющие данные и возвращающие результат типа <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TQuery">Тип запроса.</typeparam>
    /// <typeparam name="TResult">Тип ожидаемого результата.</typeparam>
    public abstract class QueryHandler<TQuery, TResult> : HandlerBase<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Обрабатываемый запрос.
        /// </summary>
        protected TQuery Query => Request;

        /// <summary>
        /// Выполнить запрос и вернуть его результат.
        /// </summary>
        /// <returns>Результат запроса.</returns>
        protected override async Task<TResult> Handle() => await GetData().ConfigureAwait(false);

        /// <summary>
        /// Абстрактный метод получения данных результата запроса.
        /// </summary>
        /// <returns>Данные результата запроса.</returns>
        protected abstract Task<TResult> GetData();

        public override string ToString() => $"{GetType().Name} | {Query}";
    }
}