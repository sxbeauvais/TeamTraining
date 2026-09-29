using System;

namespace ExceptionHandlingDemo.Business.Exceptions
{
    // Strategies that handle exceptions properly should catch the raw/technical
    // exception and rethrow one of these instead. Only this message is ever
    // shown to the user - the original exception is kept as the InnerException
    // for logging/diagnostics, not for display.
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message)
            : base(message)
        {
        }
    }
}
