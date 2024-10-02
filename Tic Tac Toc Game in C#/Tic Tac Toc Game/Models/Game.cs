using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toc_Game.Models
{
    internal class Game
    {
        private Grid grid = new Grid();
        private ComputerAsPlayer computerAsPlayer;
        private WinningLogic winningLogic = new WinningLogic();

        static int[,] positions = new int[3, 3]; // 3x3 grid for a Tic-Tac-Toe game

        public void StartApp()
        {
            String title = string.Empty;

            title = "Welcome to Unit Converter App";
            Grid.Welcomegrid(title);

            bool choice= Grid.ChooseGameMode();

            if (choice)
            {
                
                title = "You are playing with Computer";
                playGame(title,);

            }
            else
            {
                title = "You are playing with Friend";
                playGame(title);
            }
        }
        private void playGame(string title)
        {
            while (true)
            {
                Grid.DrawGrid(title, positions);
                int winner = winningLogic.CheckWinner(positions);
                if (winningLogic != null)
                {

                }
            }
        }
    }
}
