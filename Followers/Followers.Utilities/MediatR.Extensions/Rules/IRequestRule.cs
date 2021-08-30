using System.Collections.Generic;
using Utilities.MediatR.Extensions.Base;
using Utilities.MediatR.Extensions.Exceptions;

namespace Utilities.MediatR.Extensions.Rules
{
    public interface IRequestRule
    {
        /// <summary>
        /// Провалидировать параметры реквеста.
        /// </summary>
        /// <param name="request">Экземпляр реквеста.</param>
        /// <returns>Список ошибок валидации.</returns>
        ICollection<ValidationError> Validate(IRequestBase request);
    }
}