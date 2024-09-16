using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter.Models
{
    public class Grid
    {
        static int screenWidth = 50;
        static int screenHeight = 30;

        internal void Welcomegrid(String welcomeMessage)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
            int centerX = screenWidth / 2 - (welcomeMessage.Length/2);
            int centerY = screenHeight / 2;
            
            bool flag = true;//show title or not
            while (true)//for blinking effect of title
            {
                Console.SetCursorPosition(0, 0);
                
                Console.WriteLine(new string('-', screenWidth + 2));//top border of screen
                for (int i = 0; i < centerY - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");//for empty space and left and right border of screen

                //logic of blinking effect of title
                if (flag) Console.WriteLine("|" + new string(' ', centerX) + welcomeMessage + new string(' ', screenWidth - centerX - welcomeMessage.Length) + '|');//title at center of screen 
                else Console.WriteLine("|" + new string(' ', screenWidth) + "|");


                for (int i = centerY; i < screenHeight - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");//rest of screen with left and right border

                Console.WriteLine(new string('-', screenWidth + 2));//bottom border of screen

                Console.WriteLine("\nPress Enter to start...");

                //if user press enter then break the loop
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) break;

                //for blinking effect
                flag = !flag;
                Thread.Sleep(500);//in miliseconds
                Console.Clear();
                Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
            }
            Console.Clear();

        }

        internal int ShowMenu(String title, List<string> units)
        {
            int selectedIndex = 0;
            bool flag = true;
            int centerX = screenWidth / 2 - (title.Length / 2); // center for the welcome message
            int centerY = screenHeight / 2 - units.Count / 2;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
                Console.WriteLine(new string('-', screenWidth + 2)); // top border of screen

                // Split the title by newline character to handle multi-line titles
                string[] titleLines = title.Split('\n');

                // Calculate the vertical space before the title (centering the title vertically)
                int titleHeight = titleLines.Length;
                int topPadding = centerY - titleHeight;

                // Print empty lines before the title
                for (int i = 0; i < topPadding; i++)
                    Console.WriteLine("|" + new string(' ', screenWidth) + '|');

                // Print each line of the title centered
                foreach (string line in titleLines)
                {
                    int titleCenterX = screenWidth / 2 - (line.Length / 2);
                    Console.WriteLine("|" + new string(' ', titleCenterX) + line + new string(' ', screenWidth - titleCenterX - line.Length) + '|');
                }

                // Print an empty line after the title
                Console.WriteLine("|" + new string(' ', screenWidth) + '|');

                // Display unit options
                for (int i = 0; i < units.Count; i++)
                {
                    string unit = units[i];
                    int unitCenterX = screenWidth / 2 - (unit.Length / 2);
                    if (i == selectedIndex)
                        Console.WriteLine("|" + new string(' ', unitCenterX) + (flag ? unit : new string(' ', unit.Length)) + new string(' ', screenWidth - unitCenterX - unit.Length) + '|');
                    else
                        Console.WriteLine("|" + new string(' ', unitCenterX) + unit + new string(' ', screenWidth - unitCenterX - unit.Length) + '|');
                }

                // Fill the remaining space at the bottom
                for (int i = centerY + units.Count + 1; i < screenHeight - 1; i++)
                    Console.WriteLine("|" + new string(' ', screenWidth) + "|");

                Console.WriteLine(new string('-', screenWidth + 2)); // bottom border of screen
                Console.WriteLine("\nUse Arrow Keys to select and Press Enter to confirm...");
                // Console.WriteLine("Press 'Esc' to exit the application.");

                // Handle user input for navigating the unit list
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : units.Count - 1;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        selectedIndex = (selectedIndex + 1) % units.Count;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                flag = !flag;
                Thread.Sleep(400); // blinking delay
            }
            Console.Clear();
            return selectedIndex; // return the selected unit
        }

        public static double GetUnitValue(string unitName)
        {
            string valueStr = "";  // To store the input value as a string
            bool inputComplete = false;
            int centerX = screenWidth / 2;
            int centerY = screenHeight / 2;

            while (!inputComplete)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
                Console.WriteLine(new string('-', screenWidth + 2)); // top border of screen

                // Calculate vertical padding for centering the input prompt
                int promptPadding = centerY - 2;

                // Print empty lines before the input prompt to center it vertically
                for (int i = 0; i < promptPadding; i++)
                    Console.WriteLine("|" + new string(' ', screenWidth) + '|');

                // Center the prompt message horizontally
                string title = $"Enter the value for {unitName}:";
                int promptCenterX = centerX - (title.Length / 2);
                Console.WriteLine("|" + new string(' ', promptCenterX) + title + new string(' ', screenWidth - promptCenterX - title.Length) + '|');

                // Print an empty line to add spacing between prompt and value input
                Console.WriteLine("|" + new string(' ', screenWidth) + '|');

                // Center the current input value horizontally
                int valueCenterX = centerX - (valueStr.Length / 2);
                Console.WriteLine("|" + new string(' ', valueCenterX) + valueStr + new string(' ', screenWidth - valueCenterX - valueStr.Length) + '|');

                // Fill the remaining space at the bottom
                for (int i = centerY + 2; i < screenHeight - 1; i++)
                    Console.WriteLine("|" + new string(' ', screenWidth) + '|');

                Console.WriteLine(new string('-', screenWidth + 2)); // bottom border of screen

                // Handle user input for entering the value
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // If the key is a digit or period, add it to the input string
                if (char.IsDigit(keyInfo.KeyChar) || keyInfo.KeyChar == '.')
                {
                    valueStr += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && valueStr.Length > 0)
                {
                    // Remove the last character when backspace is pressed
                    valueStr = valueStr.Substring(0, valueStr.Length - 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter && !string.IsNullOrEmpty(valueStr))
                {
                    // When Enter is pressed and input is valid, complete the input
                    inputComplete = true;
                }
            }

            // Convert the input string to a double and return the value
            return double.Parse(valueStr);
        }


    }


}
