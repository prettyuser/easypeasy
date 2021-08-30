using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.MediatR.Extensions.Exceptions
{
    public class RequestValidationException : Exception
    {
        /// <summary>
        /// Набор ошибок валидации.
        /// </summary>
        public ICollection<ValidationError> Errors { get; set; }

        /// <param name="msg">Сообщение об ошибке валидации.</param>
        /// <param name="errors">Список ошибок валидации.</param>
        public RequestValidationException(string msg, IEnumerable<ValidationError> errors) : base(msg)
        {
            if (errors is ICollection<ValidationError> collection)
                Errors = collection;
            else
                Errors = errors.ToList();
        }

        /// <param name="msg">Сообщение об ошибке валидации.</param>
        public RequestValidationException(string msg) : this(msg, new List<ValidationError>(0))
        { }

        /// <param name="errors">Список ошибок валидации.</param>
        public RequestValidationException(IEnumerable<ValidationError> errors) : this("Request validation error", errors)
        { }

        public RequestValidationException() : this("Request validation error")
        { }

        /// <param name="msg">Сообщение об ошибке валидации.</param>
        /// <param name="propertyName">Название свойства, непрошедшего валидацию.</param>
        /// <param name="value">Невалидное значение свойства.</param>
        public RequestValidationException(string msg, string propertyName, object value) : this(msg)
        {
            Errors = new List<ValidationError> { new ValidationError(msg, propertyName, value) };
        }

        public override string ToString() => Errors.Count switch
        {
            0 => Message,
            1 => $"{Errors.First()}",
            _ => $"{Message} | {Errors.Count} errors"
        };
    }
}