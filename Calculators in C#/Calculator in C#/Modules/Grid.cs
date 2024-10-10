using System;
using System.Threading;

namespace Calculator_in_C_.Modules
{
    internal class Grid
    {
        static int sW = 25; // Screen Width of calculator
        static int sH = 13; // Screen Height of calculator

        private readonly string[] buttons = new string[]
        {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "0", ".", "=", "+"
        };
        private string display = ""; // Holds current input or result

        internal void getIntro()
        {
            string Message = "Welcome to Base Calculator!!!";
            displyGrid(Message);
        }

        // This method will display the calculator and return the final input string (expression)
        internal string getInput()
        {
            showCalculator();  // Show the calculator interface and capture the input
            return display;    // Return the input string (user input) to be processed elsewhere
        }

        // Show the calculator and handle user input
        private void showCalculator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('-', sW + 2));
                Console.WriteLine($"|{display.PadLeft(sW, ' ')}|");
                Console.WriteLine(new string('-', sW + 2));

                for (int i = 0; i < buttons.Length; i++)
                {
                    if (i % 4 == 0) Console.Write("|");
                    Console.Write($" {buttons[i],-3}");
                    if ((i + 1) % 4 == 0)
                    {
                        Console.WriteLine("|");
                        Console.WriteLine($"|{"".PadLeft(sW, ' ')}|"); // Add a blank row after each button row
                    }
                }
                Console.WriteLine(new string('-', sW + 2));

                if (HandleInput()) break; // Exit when the user presses '=' or Enter
            }
        }

        // Handles user input and modifies the display
        private bool HandleInput()
        {
            var keyInfo = Console.ReadKey(true);
            var key = keyInfo.KeyChar;

            if (key == '.' || key == '*' || key == '/' || key == '+' || key == '-' || char.IsDigit(key))
            {
                display += key; // Display current input
            }
            else if (key == '=' || key == '\r') // Enter or '=' to calculate/return input
            {
                return true; // Signal to return the input for further calculation
            }
            else if (key == 'c' || key == 'C')
            {
                display = ""; // Clear display
            }

            return false; // Continue capturing input
        }

        // This method will update the display with the result
        internal void updateDisplay(string result)
        {
            display = result;
            showCalculator();  // Re-display the calculator with the updated result
        }

        // Goodbye message after exiting
        internal void goodByeDisply()
        {
            string goodByeMessage = "Thank You for visiting!!!";
            displyGrid(goodByeMessage);
        }

        // Display grid for the welcome and goodbye messages
        private void displyGrid(string Message)
        {
            Console.Clear();
            int centerX = Math.Max(0, (sW - Message.Length) / 2);
            int centerY = sH / 2;
            bool flag = true; // Toggle for blinking effect

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(new string('-', sW + 2)); // Top border

                // Empty rows before the message
                for (int i = 0; i < centerY - 1; i++)
                    Console.WriteLine("|" + new string(' ', sW) + "|");

                // Display the message in the center with blinking effect
                if (flag)
                {
                    string displayMessage = Message.Length > sW ? Message.Substring(0, sW) : Message;
                    string paddingLeft = new string(' ', centerX);
                    string paddingRight = new string(' ', Math.Max(0, sW - centerX - displayMessage.Length));
                    Console.WriteLine($"|{paddingLeft}{displayMessage}{paddingRight}|");
                }
                else
                {
                    Console.WriteLine("|" + new string(' ', sW) + "|");
                }

                // Empty rows after the message
                for (int i = centerY; i < sH - 1; i++)
                    Console.WriteLine("|" + new string(' ', sW) + "|");

                Console.WriteLine(new string('-', sW + 2)); // Bottom border

                Console.WriteLine("\nPress Enter for the next move...");

                // Break on Enter key press
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) break;

                flag = !flag; // Toggle blinking
                Thread.Sleep(500); // Delay for blinking
                Console.Clear();
            }
        }
    }
}
