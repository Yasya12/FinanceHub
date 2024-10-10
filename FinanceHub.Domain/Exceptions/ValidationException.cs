namespace FinanceHub.Core.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; }

    public ValidationException(string message) : base(message)
    {
        Errors = new[] { message };
    }

    public ValidationException(IEnumerable<string> errors)
    {
        Errors = errors ?? new string[] { };
    }

    public ValidationException(string message, IEnumerable<string> errors) : base(message)
    {
        Errors = errors ?? new string[] { };
    }
}