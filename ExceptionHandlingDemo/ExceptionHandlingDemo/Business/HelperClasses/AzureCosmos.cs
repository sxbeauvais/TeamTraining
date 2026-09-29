using ExceptionHandlingDemo.Business.Models;
using ExceptionHandlingDemo.Business.Models.Interfaces;
using ExceptionHandlingDemo.Common.Exception;

namespace ExceptionHandlingDemo.Business.HelperClasses
{
    public class AzureCosmos
    {
        public void GetUser(int id)
        {
            var users = GetUsers();

            if (id <= 0)
            {
                throw new AppException.ValidationException("User Id must be greater than 0");
            }

            if (id == 911)
            {
                throw new AppException.UnauthorizedAccessException($"User Id '{id}' is restricted and cannot be accessed.");
            }

            var existingUser = users.Where(u => u.Id == id).FirstOrDefault();

            if (existingUser is null)
            {
                throw new AppException.NotFoundException("Authentication", id);
            }

            GreetUser(existingUser);
        }

        private List<IUser> GetUsers()
        {
            List<IUser> users = new List<IUser>
            {
                new User { Id = 100, Name = "John Smith"},
                new User { Id = 201, Name = "Jane Doe"},
                new User { Id = 301, Name = "Sebastien Beauvais"}
            };

            return users;
        }

        private void GreetUser(IUser user)
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome, {user.Name}");
            Console.WriteLine();
        }
    }
}
