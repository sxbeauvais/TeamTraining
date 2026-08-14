using DemoTesting.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DemoTesting.Business
{
    public class HandleUserSelection : IHandleUserSelection
    {
        public void HandleSelection()
        {
            PrintMenu();
            var userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("You selected option 1.");
                    break;
                case "2":
                    Console.WriteLine("You selected option 2.");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Run a credit check");
            Console.WriteLine("2 - Deposit cash");
            Console.Write("What would you like to do?: ");
        }
    }
}
