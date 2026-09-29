using ExceptionHandlingDemo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExceptionHandlingDemo.Presentation
{
    public class Demo
    {
        private readonly IUserInputService _inputService;
        public Demo(IUserInputService inputService) 
        {
            _inputService = inputService;
        }

        public void Start()
        {
            DisplayGreetings();
            PrintMenuOptions();

            string? userInput;
            do
            {
                Console.Write("\nWhat would you like to do: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    _inputService.HandleUserSelection(userInput);
                }
            } while (userInput != "0");
        }

        private void DisplayGreetings()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Welcome to the Exception Handling Demo!");
            Console.WriteLine("The goal of this demo is to demonstrate proper exception handling");
            Console.WriteLine("as well as differing levels of implementation. Without further");
            Console.WriteLine("a-do, lets get started!");
            Console.WriteLine("=========================================================");
            Console.WriteLine();
            Console.WriteLine();
        }

        private void PrintMenuOptions()
        {
            Console.WriteLine("1. Show a TERRIBLE example. (Yuck)");
            Console.WriteLine("2. Show a bad example. (Ew)");
            Console.WriteLine("3. Show an OK exmaple.");
            Console.WriteLine("4. Show a Good exmaple. (Now we gettin somewhere)");
            Console.WriteLine("5. Show an Excellent example. (fr fr 100%)");
            Console.WriteLine();
            Console.WriteLine("Input 0 to exit.");
        }
    }
}
