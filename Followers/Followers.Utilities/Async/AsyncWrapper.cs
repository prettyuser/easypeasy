using System;
using System.Threading.Tasks;

namespace GoodsForecast.Useful.Async
{
    /// <summary>
    /// Обертка для вызова асинхронных методов disposable типа. чтобы можно было создать Task, а await где-то ниже. Task.Run в качестве такой обертки лучше не использовать
    /// В случае применения в качестве обертки для using обязательно использовать async лямбда выражение.
    /// Если оставить его синхронным, а внутренний вызываемый метод будет асинхронным,
    /// то будет вылетать исключение в runtime из-за того, что выделенный контекст будет disposed.
    /// </summary>
    /// <example>
    /// var factTask = AsyncWrapper.Run(async () =>
    /// {
    ///        using (var dc = DbProvider.GetContext())
    ///        {
    ///            return await dc.GetFacts(filterId, rq.DateFrom, rq.DateTo, isCost: false);
    ///        }
    ///});
    /// ...
    /// await factTask;
    /// </example>
    public static class AsyncWrapper
    {
        /// <summary>
        /// Выполнить асинхронный делегат.
        /// </summary>
        /// <param name="func">Асинхронный делегат для выполнения.</param>
        /// <returns>Task для ожидания асинхронного результата.</returns>
        public static async Task Run(Func<Task> func) => await func().ConfigureAwait(false);

        /// <summary>
        /// Выполнить асинхронный делегат.
        /// </summary>
        /// <param name="func">Асинхронный делегат для выполнения.</param>
        /// <returns>Task для ожидания асинхронного результата.</returns>
        public static async Task<TResult> Run<TResult>(Func<Task<TResult>> func)
            => await func().ConfigureAwait(false);
    }
}