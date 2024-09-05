using Tic_Tac_Toc_Game.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game(); 
        Grid grid = new Grid();

        bool choice = grid.WelcomeGrid();

        if (choice)
        {
            Console.Clear();
            Console.WriteLine("Hello Gamer Lets play with me ., my name is Lucifer ,i'm uttam's buddy!!!");
            //game.PlaySinglePlayerGame();
        }
        else 
        {
            //game.PlayTwoPlayerGame();
        }
       
    }
}
    