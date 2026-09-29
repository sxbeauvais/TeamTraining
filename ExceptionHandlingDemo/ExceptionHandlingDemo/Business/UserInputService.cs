using ExceptionHandlingDemo.Business.Exceptions;
using ExceptionHandlingDemo.Business.Interfaces;
using System;

namespace ExceptionHandlingDemo.Business
{
    public class UserInputService : IUserInputService
    {
        private readonly IUserInputContext _context;
        public UserInputService(IUserInputContext context)
        {
            _context = context;
        }
        public void HandleUserSelection(string userInput)
        {
            if (!Enum.TryParse<MenuOption>(userInput, out var option) || option == MenuOption.Exit)
            {
                return;
            }

            try
            {
                _context.Execute(option);
            }
            catch (UserFriendlyException ex)
            {
                // Well-behaved strategies throw this type with a safe message.
                // Only the message is shown - no stack trace, no internal details.
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                // Anything else (Terrible/Bad strategies) means the raw, unfiltered
                // exception leaked out - so we show everything, warts and all.
                Console.WriteLine();
                Console.WriteLine("An unhandled exception was thrown:");
                Console.WriteLine(ex);
                Console.WriteLine();
            }
        }
    }
}
