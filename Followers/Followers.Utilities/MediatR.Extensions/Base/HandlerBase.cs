using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Utilities.MediatR.Extensions.Base
{
    
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequestBase, IRequest<TResponse>
    {
        protected TRequest Request;
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken _)
        {
            Request = request;

            var result = await Handle().ConfigureAwait(false);

            return result;
        }
        
        protected abstract Task<TResponse> Handle();

        public override string ToString() => $"{GetType().Name} | {Request}";
    }
}
