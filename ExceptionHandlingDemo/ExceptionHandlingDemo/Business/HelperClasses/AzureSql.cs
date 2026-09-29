using ExceptionHandlingDemo.Business.Models;
using ExceptionHandlingDemo.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExceptionHandlingDemo.Business.HelperClasses
{
    public class AzureSql
    {
        public void GetUserCredentialsForTerribleExample()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetUserCredentialsForBadExample()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetUserCredentialsForOkExample()
        {
            throw new Exception("Failed to retrieve user credentials.");
        }

        public void GetUserCredentials(int id)
        {
            var users = GetUsers();
            
            if (id <= 0)
            {
                throw new ValidationException("User Id must be greater than 0");
            }

            var existingUser = users.Where(u => u.Id == id).FirstOrDefault();

            if(existingUser is null)
            {
                throw new KeyNotFoundException($"Key not found: {id}");
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
