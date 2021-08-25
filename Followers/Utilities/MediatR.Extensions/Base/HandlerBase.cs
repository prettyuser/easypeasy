using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoodsForecast.Mediatr.Extensions.Base
{
    /// <summary>
    /// Базовый тип хендлеров, выполняющих реквесты типа <see cref="TRequest"/> и возвращающих результат типа <see cref="TResponse"/>.
    /// </summary>
    /// <typeparam name="TRequest">Тип реквеста.</typeparam>
    /// <typeparam name="TResponse">Тип результата.</typeparam>
    /// <typeparam name="TNotification">Тип уведомления о выполнении реквеста.</typeparam>
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequestBase, IRequest<TResponse>
    {
        /// <summary>
        /// Текущий реквест.
        /// </summary>
        protected TRequest Request;

        /// <summary>
        /// Выполнить реквест и вернуть его результат.
        /// </summary>
        /// <param name="request">Экземпляр реквеста.</param>
        /// <param name="_">Токен отмены выполнения реквеста. Не применяется.</param>
        /// <returns>Результат реквеста.</returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken _)
        {
            Request = request;
            TResponse result;
            
            result = await Handle().ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Обработать реквест и вернуть результат.
        /// </summary>
        /// <returns>Результат реквеста.</returns>
        protected abstract Task<TResponse> Handle();

        public override string ToString() => $"{GetType().Name} | {Request}";
    }
}