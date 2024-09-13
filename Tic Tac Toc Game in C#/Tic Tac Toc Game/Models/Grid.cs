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
        public bool WelcomeGrid() {
            //bool choice = false;
            String welcomeMessage = "Welcome to Tic Tac Toe Game!";
            int centerX = screenWidth / 2 - (welcomeMessage.Length / 2);//center of screen except title
            int centerY = screenHeight / 2;//center of screen
            bool flag = true;//show title or not

            while (true)//for blinking effect of title
            {
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
                Thread.Sleep(450);//in miliseconds
                Console.Clear();
            }
            Console.Clear();

            return ChooseGameMode();
        }
        private bool ChooseGameMode() {
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
       

        public void DrawBoard(String welcomeMessage, char currentPlayer,int row, int col)
        {
            //String welcomeMessage = "You Choose Multiplayer!";
            /*int centerX = screenWidth / 2 - (welcomeMessage.Length / 2);//center of screen except title
            int topY = 7;
            char[] playerMarker = "X | 0".ToCharArray();
            int markerCenterX = screenWidth / 2 - (playerMarker.Length / 2);

            while (true)
            {
                Console.WriteLine(new string('-', screenWidth + 2));//top border of screen
                for (int i = 0; i < topY / 2 - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");//for empty space and left and right border of screen
                Console.WriteLine("|" + new string(' ', centerX) + welcomeMessage + new string(' ', screenWidth - centerX - welcomeMessage.Length) + '|');//title at center of screen 
                for (int i = 0; i < topY / 2; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");//for empty space and left and right border of screen
               for(int i = 0; i < 3; i++)
                {

                }
                Console.WriteLine("|" + new string(' ', markerCenterX) + playerMarker + new string(' ', screenWidth - markerCenterX - playerMarker.Length) + '|');
                for (int i = 0; i < topY / 2 - 1; i++) Console.WriteLine("|" + new string(' ', screenWidth) + "|");//for empty space and left and right border of screen
                DrawGameBoard(currentPlayer, row, col);
            }
*/
        }
        /*private char[] BlinkMarker(char marker, char[] playerMarker)
        {
            if(marker == 'X') playerMarker = "  | 0".ToCharArray();
            else playerMarker = "X |  ".ToCharArray();
            return playerMarker;
        }*/
    }
}
