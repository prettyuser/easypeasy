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
        
        public string ErrorMessage { get; set; }

        public string PropertyName { get; set; }

        public object AttemptedValue { get; set; }

        public override string ToString()
        {
            return AttemptedValue != null
                ? $"{PropertyName} ({AttemptedValue}): {ErrorMessage}"
                : $"{PropertyName}: {ErrorMessage}";
        }
    }
}
