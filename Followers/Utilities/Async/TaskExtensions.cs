using System.Threading.Tasks;

namespace GoodsForecast.Useful.Async
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Нефункциональный маркер целенаправленного игнорирования ожидания выполнения асинхронной задачи. 
        /// </summary>
        /// <param name="_">Асинхронная задача, для которой не требуется ожидание.</param>
        public static void WithNoAwait(this Task _) { }
    }
}