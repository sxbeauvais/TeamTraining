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
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("An unhandled exception was thrown:");
                Console.WriteLine(ex);
                Console.WriteLine();
            }
        }
    }
}
