using System;

namespace ExceptionHandlingDemo.Middleware
{
    // Anything that wants to be pluggable via UseMiddleware<TMiddleware, TStrategy>()
    // needs to expose this shape: run an action, decide what (if anything) to do
    // when it throws.
    public interface IExceptionMiddleware
    {
        void Execute(Action action);
    }
}
