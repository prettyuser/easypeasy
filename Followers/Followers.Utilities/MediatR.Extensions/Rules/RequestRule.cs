using System;
using System.Collections.Generic;
using Utilities.MediatR.Extensions.Base;
using Utilities.MediatR.Extensions.Exceptions;

namespace Utilities.MediatR.Extensions.Rules
{
    public abstract class RequestRule<T, TRequestInterface> : IRequestRule
        where TRequestInterface : IRequestWithRule<T, IRequestRule>
    {
        protected abstract Func<TRequestInterface, T> GetItem { get; }
        
        public ICollection<ValidationError> Validate(IRequestBase request) => Validate(GetItem((TRequestInterface)request));
        
        public virtual ICollection<ValidationError> Validate(T item) => new List<ValidationError>(0);
    }
}