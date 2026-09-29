using ExceptionHandlingDemo.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExceptionHandlingDemo.Common.Exception
{
    public abstract class AppException : UserFriendlyException
    {
        protected AppException(string message) : base(message) { }

        public sealed class NotFoundException : AppException
        {
            public NotFoundException(string resouce, object key) : base($"{resouce} with key '{key}' was not found.") { }
        }

        public sealed class ValidationException : AppException
        {
            public ValidationException(string message) : base(message) { }
        }
    }
}
