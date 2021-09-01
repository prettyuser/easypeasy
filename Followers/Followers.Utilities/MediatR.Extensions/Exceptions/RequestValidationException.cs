using System;
using System.Linq;
using System.Collections.Generic;

namespace Utilities.MediatR.Extensions.Exceptions
{
    public class RequestValidationException : Exception
    {
        private ICollection<ValidationError> Errors { get; }

        private RequestValidationException(string msg, IEnumerable<ValidationError> errors) : base(msg)
        {
            if (errors is ICollection<ValidationError> collection)
                Errors = collection;
            else
                Errors = errors.ToList();
        }

        public RequestValidationException(IEnumerable<ValidationError> errors) : this("Request validation error", errors)
        { }

        public override string ToString() => Errors.Count switch
        {
            0 => Message,
            1 => $"{Errors.First()}",
            _ => $"{Message} | {Errors.Count} errors"
        };
    }
}
