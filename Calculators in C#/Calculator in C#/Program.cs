
using System;
using Calculator_in_C_.Modules;  // Import the Modules namespace

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Console App!");

            // Create an instance of AppStarter and call RunApp
            var appStarter = new CalculatorEngine();
            appStarter.RunApp();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

