using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toc_Game.Models
{
    public class Game
    {
        private Grid grid;
        private ComputerAsPlayer computerAsPlayer;
        private WinningLogic winningLogic;

        public Game(){
            this.grid = new Grid();
            this.computerAsPlayer = new ComputerAsPlayer();
            this.winningLogic = new WinningLogic(); 
        }

        public void PlayWithyourFriend()
        {
            String welcomeMessage = "You Choose Multiplayer!";
            grid.DrawBoard(welcomeMessage);
        }

    }
}
