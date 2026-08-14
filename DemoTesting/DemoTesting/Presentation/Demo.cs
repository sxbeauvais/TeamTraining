using System;
using System.Collections.Generic;
using System.Text;
using DemoTesting.Business.Interfaces;

namespace DemoTesting.Presentation
{
    public class Demo
    {
        private readonly IHandleUserSelection _handleUserSelection;

        public Demo(IHandleUserSelection handleUserSelection)
        {
            _handleUserSelection = handleUserSelection;
        }

        public void Start()
        {
            PrintWelcomeMessage();
            _handleUserSelection.HandleSelection();

        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine("============================================= Unit Testing Demo =============================================\n");
            Console.WriteLine("Unit tests have several benefits to ensure the quality of your code.");
            Console.WriteLine("One such benefit is that is ensure you are writing code in accordance to business requirements.");
            Console.WriteLine("Another is that it allows you to isolate your code and test it in a controlled environment.");
            Console.WriteLine("=============================================================================================================\n");
        }
    }
}
