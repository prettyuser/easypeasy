namespace Utilities.MediatR.Extensions.Exceptions
{
    public class ValidationError
    {
        public ValidationError() { }
        
        public ValidationError(string msg, string propertyName, object value)
        {
            ErrorMessage = msg;
            PropertyName = propertyName;
            AttemptedValue = value;
        }

        /// <summary>
        /// Сообщение об ошибке валидации.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Название свойства, непрошедшего валидацию.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Невалидное значение свойства.
        /// </summary>
        public object AttemptedValue { get; set; }

        public override string ToString()
        {
            return AttemptedValue != null
                ? $"{PropertyName} ({AttemptedValue}): {ErrorMessage}"
                : $"{PropertyName}: {ErrorMessage}";
        }
    }
}