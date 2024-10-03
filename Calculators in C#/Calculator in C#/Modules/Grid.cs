using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_in_C_.Modules
{
    internal class Grid
    {
        static int sW = 25;// Screen Width of calculator
        static int sH = 13;// Screen Height of calculator

        private readonly string[] buttons = new string[]
        {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "0", ".", "=", "+"
        };
        private string display = "";// Holds current input or reault
        internal void getIntro()
        {
            string Message = "Welcome to Base Calculator!!!";
            displyGrid(Message);
        }

        internal string getInput()
        {
            showCalculator();
           
            return display;
        }


        private void showCalculator()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('-', sW + 2));
                Console.WriteLine($"|{display.PadLeft(sW,' ')}|");
                Console.WriteLine(new string ('-', sW + 2));

                for(int i = 0; i < buttons.Length; i++)
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
                Console.WriteLine("Enter 'c' for clear display \n Enter 'E' to exit!!!");
                if (HandleInput()) break; // Exit when the user presses '=' or Enter
            }
        }
        private bool HandleInput()
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key == '.' || key == '*' || key == '/' || key == '+' || key == '-' || char.IsDigit(key)) display += key; // Display your current input
            else if (key == '=' || key == '\r')// '\r' is for Enter
            {
                try
                {
                    return true; // Signal to return the input for further calculation
                }
                catch
                {
                    display += "error";
                }
            }
            else if (key == 'c' || key == 'C') display = "";//clear display
            else if (key == 'e' || key == 'E') //exit
            {
                display = "exit";
                return true;
            }
                return false;// Continue capturing input
        }

        internal void goodByeDisply()
        {
            string goodByeMessage = "Thank You for visting!!!";
            displyGrid(goodByeMessage);
        }
        private void displyGrid(string Message)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
            int centerX = sW / 2 - (Message.Length / 2);
            int centerY = sH / 2;

            bool flag = true;//show title or not
            while (true)//for blinking effect of title
            {
                Console.SetCursorPosition(0, 0);

                Console.WriteLine(new string('-', sW + 2));//top border of screen
                for (int i = 0; i < centerY - 1; i++) Console.WriteLine("|" + new string(' ', sW) + "|");//for empty space and left and right border of screen

                //logic of blinking effect of title
                if (flag) Console.WriteLine("|" + new string(' ', centerX) + Message + new string(' ', sW - centerX - Message.Length) + '|');//title at center of screen 
                else Console.WriteLine("|" + new string(' ', sW) + "|");


                for (int i = centerY; i < sH - 1; i++) Console.WriteLine("|" + new string(' ', sW) + "|");//rest of screen with left and right border

                Console.WriteLine(new string('-', sW + 2));//bottom border of screen

                Console.WriteLine("\nPress Enter for next move...");

                //if user press enter then break the loop
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) break;

                //for blinking effect
                flag = !flag;
                Thread.Sleep(500);//in miliseconds
                Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
                Console.Clear();
            }
            Console.Clear();

        }
    }
}
