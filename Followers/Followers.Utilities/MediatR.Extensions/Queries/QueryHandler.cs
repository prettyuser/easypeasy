using System.Threading.Tasks;
using Utilities.MediatR.Extensions.Base;

namespace Utilities.MediatR.Extensions.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : HandlerBase<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private TQuery Query => Request;
        
        protected override async Task<TResult> Handle() => await GetData().ConfigureAwait(false);
        
        protected abstract Task<TResult> GetData();

        public override string ToString() => $"{GetType().Name} | {Query}";
    }
}
