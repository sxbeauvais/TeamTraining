using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ExceptionHandlingDemo.Common.Logging
{
    // A minimal ILogger that appends every log line to a single text file, so
    // ILogger<T> can be injected the same way it would be in a real app, without
    // pulling in a full logging framework like Serilog for this demo.
    public sealed class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;
        private readonly object _writeLock;

        public FileLogger(string categoryName, string filePath, object writeLock)
        {
            _categoryName = categoryName;
            _filePath = filePath;
            _writeLock = writeLock;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, System.Exception? exception, Func<TState, System.Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var line = $"\n{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_categoryName}: {formatter(state, exception)}";
            if (exception is not null)
            {
                line += Environment.NewLine + exception;
            }

            lock (_writeLock)
            {
                File.AppendAllText(_filePath, line + Environment.NewLine);
            }
        }
    }
}
