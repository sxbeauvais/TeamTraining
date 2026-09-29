using ExceptionHandlingDemo.Common.Exception;
using Microsoft.Extensions.Logging;
using System;

namespace ExceptionHandlingDemo.Middleware
{
    // Centralizes exception-to-console translation for known, expected exception
    // types. Every exception gets logged to file first (so nothing is ever lost),
    // then only known types are translated into a friendly message. Anything
    // unrecognized is NOT our fault to explain nicely, so it is rethrown as-is
    // (stack trace intact) for the top-level handler to display.
    public sealed class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred while executing the Excellent example.");

                var (title, detail) = ex switch
                {
                    AppException.ValidationException => ("Validation Error", ex.Message),
                    AppException.NotFoundException => ("Not Found", ex.Message),
                    UnauthorizedAccessException => ("Forbidden", "You are not authorized to perform this action."),
                    _ => (null, null)
                };

                if (title is null)
                {
                    // Unknown exception type - rethrow untouched instead of
                    // pretending we know how to explain it to the user.
                    throw;
                }

                Console.WriteLine();
                Console.WriteLine($"{title}: {detail}");
                Console.WriteLine();
            }
        }
    }
}

