using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toc_Game.Models
{
    public class Grid
    {
        // Define the screen width and height
        static int screenWidth = 30;
        static int screenHeight = 10;

        public const int GameBoardSize = 11;
        internal static void Welcomegrid(String welcomeMessage)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0); // Set the cursor to the top-left corner (x=0, y=0)
            int centerX = screenWidth / 2 - (welcomeMessage.Length / 2);
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
        internal static bool ChooseGameMode()
        {
            bool choice = true;//at start choice is true means play with computer
            String welcomeMessage = "Choose Game Mode!";
            String choice1 = "Play with Computer";
            String choice2 = "Play with Friend";
            int centerX = screenWidth / 2 - (welcomeMessage.Length / 2);//center of screen except title
            int centerY = screenHeight / 2;//center of screen
            bool flag = true;//show title or not


            while (true)
            {
                Console.Clear();
                Console.WriteLine(new string('-', screenWidth + 2));
                for (int i = 0; i < centerY - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + '|');
                Console.WriteLine("|" + new string(' ', centerX) + welcomeMessage + new string(' ', screenWidth - centerX - welcomeMessage.Length) + '|');//title at center of screen
                Console.WriteLine("|" + new string(' ', screenWidth) + '|');
                int choice1CenterX = screenWidth / 2 - (choice1.Length / 2);
                int choice2CenterX = screenWidth / 2 - (choice2.Length / 2);

                if (choice)
                {
                    Console.WriteLine("|" + new string(' ', choice1CenterX) + (flag ? choice1 : new string(' ', choice1.Length)) + new string(' ', screenWidth - choice1CenterX - choice1.Length) + '|');
                    Console.WriteLine("|" + new string(' ', choice2CenterX) + choice2 + new string(' ', screenWidth - choice2CenterX - choice2.Length) + '|');
                }
                else
                {
                    Console.WriteLine("|" + new string(' ', choice1CenterX) + choice1 + new string(' ', screenWidth - choice1CenterX - choice1.Length) + '|');
                    Console.WriteLine("|" + new string(' ', choice2CenterX) + (flag ? choice2 : new string(' ', choice2.Length)) + new string(' ', screenWidth - choice2CenterX - choice2.Length) + '|');
                }
                for (int i = centerY + 2; i < screenHeight - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");

                Console.WriteLine(new string('-', screenWidth + 2));
                Console.WriteLine("\nUse Arrow Keys to select and Press Enter to start...");

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                    {
                        choice = !choice; // Toggle between 0 and 1
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        break; // Exit loop on Enter
                    }
                }
                flag = !flag;
                Thread.Sleep(450);

            }
            return choice;
        }
        internal static void DrawGrid(string title, int[,] positions)
        {
            int gridSize = 3; // Assuming a 3x3 Tic-Tac-Toe grid
            Console.Clear();

            // Display the title at the top
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 13)); // A simple line separator

            for (int row = 0; row < gridSize; row++)
            {
                // Print each row of the grid
                for (int col = 0; col < gridSize; col++)
                {
                    // Determine what to print in each cell (X, O, or empty)
                    string cellContent;
                    switch (positions[row, col])
                    {
                        case 1:
                            cellContent = "X"; // Player 1
                            break;
                        case 2:
                            cellContent = "O"; // Player 2
                            break;
                        default:
                            cellContent = " "; // Empty cell
                            break;
                    }

                    // Print cell with appropriate formatting
                    Console.Write($" {cellContent} ");
                    if (col < gridSize - 1)
                        Console.Write("|"); // Separate columns
                }

                Console.WriteLine(); // Move to the next line after each row

                if (row < gridSize - 1)
                {
                    // Print row separator
                    Console.WriteLine("---+---+---");
                }
            }

            Console.WriteLine(new string('-', 13)); // Bottom border
        }


    }
}
