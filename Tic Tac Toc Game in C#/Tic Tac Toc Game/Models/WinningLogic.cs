using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toc_Game.Models
{
    internal class WinningLogic
    {
        public int CheckWinner(int[,] positions)
        {
            // Check rows for a winner
            for (int row = 0; row < 3; row++)
            {
                if (positions[row, 0] == positions[row, 1] && positions[row, 1] == positions[row, 2])
                {
                    if (positions[row, 0] != 0)
                        return positions[row, 0]; // Return the winner (1 or 2)
                }
            }

            // Check columns for a winner
            for (int col = 0; col < 3; col++)
            {
                if (positions[0, col] == positions[1, col] && positions[1, col] == positions[2, col])
                {
                    if (positions[0, col] != 0)
                        return positions[0, col]; // Return the winner (1 or 2)
                }
            }

            // Check diagonals for a winner
            if (positions[0, 0] == positions[1, 1] && positions[1, 1] == positions[2, 2])
            {
                if (positions[0, 0] != 0)
                    return positions[0, 0]; // Return the winner (1 or 2)
            }
            if (positions[0, 2] == positions[1, 1] && positions[1, 1] == positions[2, 0])
            {
                if (positions[0, 2] != 0)
                    return positions[0, 2]; // Return the winner (1 or 2)
            }

            // No winner yet
            return 0;
        }

    }
}
