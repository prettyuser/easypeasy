using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mapster;

namespace Utilities.MediatR.Extensions.Exceptions
{
    public static class ValidatorExtensions
    {
        public static ICollection<ValidationError> ValidateRequest<TRequest>(this InlineValidator<TRequest> validator, TRequest request)
        {
            if (validator == null)
                return new List<ValidationError>(0);

            var errors = validator.Validate(request).Errors;
            var result = errors.Select(q => q.Adapt<ValidationError>()).ToList();
            return result;
        }
    }
}
