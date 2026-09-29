using Microsoft.Extensions.Logging;

namespace ExceptionHandlingDemo.Common.Logging
{
    public sealed class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;
        private readonly object _writeLock = new();

        public FileLoggerProvider(string filePath)
        {
            _filePath = filePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _filePath, _writeLock);
        }

        public void Dispose()
        {
        }
    }
}
